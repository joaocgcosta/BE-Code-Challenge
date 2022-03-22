using MED.MedicationManagement.Application.Responses;
using MED.MedicationManagement.Application.DTOs.Medication;
using MED.MedicationManagement.Application.Features.Medications.Requests.Commands;
using MED.MedicationManagement.Application.Features.Medications.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MED.MedicationManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<MedicationController>
        [HttpGet]
        public async Task<ActionResult<List<MedicationListDto>>> Get()
        {
            var medications = await _mediator.Send(new GetMedicationListRequest());
            return Ok(medications);
        }

        // GET api/<MedicationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicationDto>> Get(int id)
        {
            var medication = await _mediator.Send(new GetMedicationDetailRequest { Id = id });
            return Ok(medication);
        }

        // POST api/<MedicationController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMedicationDto medication)
        {
            var command = new CreateMedicationCommand { MedicationDto = medication };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<MedicationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteMedicationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
