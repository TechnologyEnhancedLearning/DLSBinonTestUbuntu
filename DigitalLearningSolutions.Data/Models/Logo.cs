﻿namespace DigitalLearningSolutions.Data.Models
{
    using System;
    using DigitalLearningSolutions.Data.Exceptions;

    public class Logo
    {
        public readonly string LogoUrl;
        public readonly string Name;

        public Logo(
            string centreName,
            byte[]? centreLogo,
            string? centreMimeType,
            string? brandName,
            byte[]? brandLogo
        )
        {
            var centreLogoData = ParseLogoData(centreLogo, centreMimeType);
            if (centreLogoData != null)
            {
                LogoUrl = centreLogoData;
                Name = centreName;
                return;
            }

            var brandLogoData = ParseLogoData(brandLogo);
            if (brandLogoData != null)
            {
                LogoUrl = brandLogoData;
                Name = brandName!;
                return;
            }

            throw new LogoNotFoundException();
        }

        private string? ParseLogoData(byte[]? logoData, string? logoMimeType = null)
        {
            logoMimeType ??= "jpeg";

            if (logoData == null || logoData.Length < 10)
            {
                return null;
            }

            var base64Logo = Convert.ToBase64String(logoData);
            return $"data:{logoMimeType};base64,{base64Logo}";
        }
    }
}
