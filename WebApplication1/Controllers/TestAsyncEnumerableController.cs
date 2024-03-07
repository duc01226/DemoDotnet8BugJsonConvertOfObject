using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class TestAsyncEnumerableController : ControllerBase
{
    public TestAsyncEnumerableController()
    {
    }

    [HttpGet]
    [Route("")]
    public IAsyncEnumerable<string> Get()
    {
        // I expect that my MyCustomObjectJsonConverter is not activated to serialize IAsyncEnumerable<string>. It should be used only for object type
        return GetAsyncContent();
    }

    private async IAsyncEnumerable<string> GetAsyncContent()
    {
        for (var i = 0; i < 10000; i++)
            yield return await Task.Run(() => Guid.NewGuid().ToString());
    }
}