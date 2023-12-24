using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Models.Dtos;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto? _response;
        private IProductRepository? _productRepository;

        public ProductAPIController(ResponseDto responseDto, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }


        [HttpGet]
        public async Task<object> Get() 
        {
            try 
            {
                IEnumerable<ProductDTO> productDTOs = await _productRepository.GetProducts();
                _response.Result = productDTOs;
            }
            catch(Exception ex) 
            {
                _response.isSuccess = false;   
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("id")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDTO productDTO = await _productRepository.GetProductById(id);
                _response.Result = productDTO;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [Route("id")]
        public async Task<object> Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                ProductDTO model = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        [Route("id")]
        public async Task<object> Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                ProductDTO model = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        [Route("id")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }
    }
}
