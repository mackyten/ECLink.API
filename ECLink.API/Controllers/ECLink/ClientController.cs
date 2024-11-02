using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ECLink.APPLICATION;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Commands = ECLink.APPLICATION.ECLink.Client.Command;  

namespace ECLink.API.Controllers.ECLink
{
    public class ClientController : BaseController
    {
        [HttpPost("create")]
        [Description("Creates new TempTestRecord")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Commands.Create.Command command)
        {

            var result = await Mediator.Send(command);

            if (result is BadRequestResponse)
            {
                return BadRequest(result.Message);
            }

            var data = ((SuccessResponse<string>)result).Data;
            return Ok(data);
        }

        // [HttpPut("update")]
        // [Description("Returns temp test records model")]
        // [ProducesResponseType(typeof(TempTestRecordModel), (int)HttpStatusCode.OK)]
        // public async Task<IActionResult> Update([FromBody] Commands.Update.Command command)
        // {
        //     var result = await Mediator.Send(command);

        //     if (result is BadRequestResponse)
        //     {
        //         return BadRequest(result.Message);
        //     }

        //     var data = ((SuccessResponse<TempTestRecordModel>)result).Data;
        //     return Ok(data);
        // }

        // [HttpDelete("delete")]
        // [Description("Returns temp test record id")]
        // [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        // public async Task<IActionResult> Delete([FromBody] Commands.Delete.Command command)
        // {
        //     var result = await Mediator.Send(command);

        //     if (result is BadRequestResponse)
        //     {
        //         return BadRequest(result.Message);
        //     }

        //     var data = ((SuccessResponse<int>)result).Data;
        //     return Ok(data);
        // }

        // [HttpGet("get-id")]
        // [Description("Query returns a TempTestRecordModel")]
        // [ProducesResponseType(typeof(TempTestRecordModel), (int)HttpStatusCode.Created)]
        // public async Task<IActionResult> GetById([FromQuery] Queries.GetById.Query query)
        // {
        //     var result = await Mediator.Send(query);
        //     if (result is BadRequestResponse)
        //     {
        //         return BadRequest(result.Message);
        //     }

        //     var data = ((SuccessResponse<TempTestRecordModel>)result).Data;
        //     return Ok(data);
        // }

        // [HttpGet("get-list")]
        // [Description("Query returns a TempTestRecordModel")]
        // [ProducesResponseType(typeof(TTRResponseModel), (int)HttpStatusCode.Created)]
        // public async Task<IActionResult> GetList([FromQuery] Queries.GetList.Query query)
        // {
        //     var result = await Mediator.Send(query);
        //     if (result is BadRequestResponse)
        //     {
        //         return BadRequest(result.Message);
        //     }

        //     var data = ((SuccessResponse<TTRResponseModel>)result).Data;
        //     return Ok(data);
        // }
    }
}