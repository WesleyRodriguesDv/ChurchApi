using ChurchApi.DTOs.Member;
using ChurchApi.Interfaces;
using ChurchApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberInterface _memberInterface;

        public MemberController(IMemberInterface memberInterface)
        {
            _memberInterface = memberInterface;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<MemberModel>>>> GetAll()
        {
            var members = await _memberInterface.GetMembers();
            return Ok(members);
        }

        [HttpGet("GetBy/{memberId}")]
        public async Task<ActionResult<ResponseModel<MemberModel>>> GetMemberById(int memberId)
        {
            var member = await _memberInterface.GetMemberById(memberId);
            return Ok(member);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<List<MemberModel>>>> CreateMember(MemberCreateDto memberCreateDto)
        {
            var member = await _memberInterface.CreateMember(memberCreateDto);
            return Ok(member);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<ResponseModel<MemberModel>>> EditMember(MemberEditDto memberEditDto)
        {
            var member = await _memberInterface.EditMember(memberEditDto);
            return Ok(member);
        }
    }
}
