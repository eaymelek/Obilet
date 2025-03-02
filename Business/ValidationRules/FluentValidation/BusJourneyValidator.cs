using Common.Constants;
using DTOs.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BusJourneyValidator : AbstractValidator<BusJourneyRequest>
    {
        public BusJourneyValidator()
        {
            RuleFor(x => x.Data).NotNull();
            RuleFor(x => x.Data.OriginId).NotNull().WithMessage(Messages.OriginIdIsRequired);
            RuleFor(x => x.Data.DestinationId).NotNull().WithMessage(Messages.DestinationIdIsRequired);
            RuleFor(x => x.Data.DepartureDate).NotNull().WithMessage(Messages.DepartureDateIsRequired);
            RuleFor(x => x.Data.OriginId).NotEqual(y => y.Data.DestinationId).WithMessage(Messages.OriginAndDestinationMustBeDifferent);
            RuleFor(x => x.Data.DepartureDate)
                    .Must(date => DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate) && parsedDate >= DateTime.Today)
                      .WithMessage(Messages.DepartureDateMustNotBeInPast);

        }
    }
}
