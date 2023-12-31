﻿namespace DigitalLearningSolutions.Web.ViewModels.TrackingSystem.Centre.Ranking
{
    using System.Collections.Generic;
    using System.Linq;
    using DigitalLearningSolutions.Data.Enums;
    using DigitalLearningSolutions.Data.Models.DbModels;
    using DigitalLearningSolutions.Web.Helpers;
    using DigitalLearningSolutions.Web.Models.Enums;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CentreRankingViewModel
    {
        public CentreRankingViewModel(
            IEnumerable<CentreRanking> centreRanks,
            int centreId,
            IEnumerable<(int, string)> regions,
            int? regionId = null,
            Period? period = null
        )
        {
            var centreRanksList = centreRanks.ToList();

            Centres = centreRanksList.OrderBy(cr => cr.Ranking)
                .Select(
                    cr => new CentreRankViewModel(
                        cr.Ranking,
                        cr.CentreName,
                        cr.DelegateSessionCount,
                        cr.CentreId == centreId
                    )
                );

            CentreHasNoActivity = centreRanksList.All(cr => cr.CentreId != centreId);

            RegionId = regionId;
            Period = period;
            RegionOptions = SelectListHelper.MapOptionsToSelectListItems(regions, regionId);
            PeriodOptions = GeneratePeriodSelectListWithSelectedItem(period?.Id);
        }

        public IEnumerable<CentreRankViewModel> Centres { get; set; }

        public bool CentreHasNoActivity { get; set; }

        public int? RegionId { get; set; }

        public IEnumerable<SelectListItem> RegionOptions { get; set; }

        public Period? Period { get; set; }

        public IEnumerable<SelectListItem> PeriodOptions { get; set; }

        private static IEnumerable<SelectListItem> GeneratePeriodSelectListWithSelectedItem(int? selectedId = null)
        {
            var values = Enumeration.GetAll<Period>();
            return values.Select(v => new SelectListItem(v.Name, v.Id.ToString(), v.Id == selectedId));
        }
    }
}
