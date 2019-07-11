

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Research.PropertyInfoes;

namespace Research.PropertyInfoes.Dtos
{
    public class CreateOrUpdatePropertyInfoInput
    {
        [Required]
        public PropertyInfoEditDto PropertyInfo { get; set; }

    }
}