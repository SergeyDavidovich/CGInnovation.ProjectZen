using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CGInnovation.ProjectZen.Risks
{
    public interface IRiskAppService :
        ICrudAppService< //Defines CRUD methods
            RiskDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateRiskDto> //Used to create/update a book
    {

    }
}
