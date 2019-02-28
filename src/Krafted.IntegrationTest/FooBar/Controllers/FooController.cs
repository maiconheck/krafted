using System;
using System.Threading.Tasks;
using Krafted.IntegrationTest.FooBar.Application;
using Krafted.IntegrationTest.FooBar.Domain;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain;

namespace Krafted.IntegrationTest.FooBar.Controllers
{
    [Route("api/v1/[Controller]")]
    public class FooController : Controller
    {
        private readonly IRepositoryAsync<Foo> _fooRepository;
        private readonly FooApplicationService _fooAppService;

        public FooController(IRepositoryAsync<Foo> fooRepository, FooApplicationService fooAppService)
        {
            _fooRepository = fooRepository;
            _fooAppService = fooAppService;
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var foo = await _fooRepository.GetByIdAsync(id);
            return Ok(foo);
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAllAsync()
        {
            var foo = await _fooRepository.GetAllAsync();
            return Ok(foo);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateFooCommand command)
        {
            var result = await _fooAppService.HandleAsync(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ChangeScheduleFooCommand command)
        {
            command.Id = id;
            var result = await _fooAppService.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _fooAppService.HandleAsync(new DeleteFooCommand(id));
            return Ok(result);
        }
    }
}
