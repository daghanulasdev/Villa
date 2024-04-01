using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.SubHeaderDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class SubHeaderController : Controller
    {
        private readonly ISubHeaderService _subHeaderService;
        private readonly IMapper _mapper;

        public SubHeaderController(ISubHeaderService subHeaderService, IMapper mapper)
        {
            _subHeaderService = subHeaderService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _subHeaderService.TGetListAsync();
            var SubHeaderList = _mapper.Map<List<ResultSubHeaderDto>>(values);
            return View(SubHeaderList);
        }

        public async Task<IActionResult> DeleteSubHeader(ObjectId id)
        {
            await _subHeaderService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateSubHeader()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubHeader(CreateSubHeaderDto createSubHeaderDto)
        {
            var newSubHeader = _mapper.Map<SubHeader>(createSubHeaderDto);
            await _subHeaderService.TCreateAsync(newSubHeader);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateSubHeader(ObjectId id)
        {
            var values = await _subHeaderService.TGetByIdAsync(id);
            var updateSubHeader = _mapper.Map<UpdateSubHeaderDto>(values);
            return View(updateSubHeader);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubHeader(UpdateSubHeaderDto updateSubHeaderDto)
        {
            var subHeader = _mapper.Map<SubHeader>(updateSubHeaderDto);
            await _subHeaderService.TUpdateAsync(subHeader);
            return RedirectToAction("Index");
        }
    }
}
