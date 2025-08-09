using FluentValidation;

namespace Movies_RestApi.Models.Validators
{
    public class MovieQueryValidator : AbstractValidator<MovieQuery>
    {
        private int[] allowedPageSizes = new int[] { 5, 10, 15 };
        public MovieQueryValidator()
        {
            RuleFor(m => m.pageNumber).GreaterThanOrEqualTo(1);
            RuleFor(m => m.pageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("pageSize", "Page size bad format");
                }
            });
        }
    }
}
