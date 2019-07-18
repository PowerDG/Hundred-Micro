
using Abp.Runtime.Validation;
using Research.Dtos;
using Research.PropertyInfoes;

namespace Research.PropertyInfoes.Dtos
{
    public class GetPropertyInfosInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
