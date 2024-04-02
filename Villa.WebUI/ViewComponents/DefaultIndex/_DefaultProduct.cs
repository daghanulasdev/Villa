﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.ProductDtos;

namespace Villa.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultProduct : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _DefaultProduct(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.TGetListAsync();
            var productList = _mapper.Map<List<ResultProductDto>>(values);
            return View(productList);
        }
    }
}
