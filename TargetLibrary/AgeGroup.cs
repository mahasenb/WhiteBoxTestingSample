using System.ComponentModel.DataAnnotations;

namespace TargetLibrary
{
    public enum AgeGroup
    {
        [Display(Name = "Less Than Twenty")]
        LessThanTwenty,
        [Display(Name = "Twenty One To Forty")]
        TwentyOneToForty,
        [Display(Name = "Forty One To Sixty")]
        FortyOneToSixty,
        [Display(Name = "Above Sixty")]
        AboveSixty
    }
}