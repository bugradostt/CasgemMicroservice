﻿using AutoMapper;
using CasgemMicroservice.Services.Catalog.Dtos.ProductDtos;
using CasgemMicroservice.Services.Catalog.Models;
using CasgemMicroservice.Services.Catalog.Settings;
using CasgemMicroservice.Shared.Dtos;
using MongoDB.Driver;

namespace CasgemMicroservice.Services.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {

            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);

        }

        public async Task<Response<NoContent>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
            return Response<NoContent>.Success(201);

        }

        public async Task<Response<NoContent>> DeleteProductAsync(string id)
        {
            var value = await _productCollection.DeleteOneAsync(x => x.ProductID == id);
                return Response<NoContent>.Success(204);
            
        }

        public async Task<Response<List<ResultProductDto>>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);

        }

        public async Task<Response<ResultProductDto>> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultProductDto>.Fail("Böyle bir id bulunamadı", 404);

            }
            else
            {
                return Response<ResultProductDto>.Success(_mapper.Map<ResultProductDto>(value), 200);
            }
        }

        public async Task<Response<NoContent>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
            return Response<NoContent>.Success(204);
            
        }
    }
}
