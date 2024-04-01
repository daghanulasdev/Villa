using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.FeatureDtos;

namespace Villa.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultFeature : ViewComponent
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public _DefaultFeature(IMapper mapper, IFeatureService featureService)
        {
            _mapper = mapper;
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.TGetListAsync();
            var featureList = _mapper.Map<List<ResultFeatureDto>>(values);
            return View(featureList); 
        }
    }
}
