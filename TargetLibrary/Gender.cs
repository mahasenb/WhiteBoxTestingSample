using System.ComponentModel.DataAnnotations;

namespace TargetLibrary
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female
    }
}