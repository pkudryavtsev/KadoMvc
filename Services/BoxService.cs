using System;
using ProductDb.DataClasses;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductDb;
using Services.Dtos;
using AutoMapper;
using Services.Helpers;
using DAL;
using System.Linq.Expressions;
using System.Linq;
using DAL.Specifications;
using DAL.Repository.Boxes;
using Services.Dtos.Boxes;

namespace Services
{
    public class BoxService
    {
        private readonly Repo _repo;
        private readonly IMapper _mapper;

        public BoxService(IMapper mapper, Repo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<IReadOnlyList<BoxToReturnDto>> GetBoxesWithParams(BoxProductParams productParams)
        {
            var specification = new BoxFilterSpecification(new BoxProductParams());

            var boxes = await _repo.GetBoxesWithSpecification(specification);

            return _mapper.Map<IReadOnlyList<Box>, IReadOnlyList<BoxToReturnDto>>(boxes);
        }

        public async Task<bool> AddBox(BoxToCreateDto boxToCreate)
        {
            var box = _mapper.Map<BoxToCreateDto, Box>(boxToCreate);

            bool isAdded = await _repo.CreateBox(box);

            return isAdded;
        }

        public Task<bool> EditBox(BoxToUpdateDto boxToUpdate)
        {
            var box = _mapper.Map<BoxToUpdateDto, Box>(boxToUpdate);

            Task<bool> isEdited = _repo.UpdateBox(box);

            return isEdited;
        }

        public async Task<bool> RemoveBox(int id)
        {
            var isDeleted = await _repo.DeleteBox(id);

            return isDeleted;
        }
    }
}
