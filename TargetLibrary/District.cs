using System.ComponentModel.DataAnnotations;

namespace TargetLibrary
{
    public enum Province
    {
        [Display(Name = "Northern")]
        Northern,
        [Display(Name = "North Western")]
        NorthWestern,
        [Display(Name = "Western")]
        Western,
        [Display(Name = "North Central")]
        NorthCentral,
        [Display(Name = "Central")]
        Central,
        [Display(Name = "Sabaragamuwa")]
        Sabaragamuwa,
        [Display(Name = "Eastern")]
        Eastern,
        [Display(Name = "Uva")]
        Uva,
        [Display(Name = "Southern")]
        Southern
    }
}