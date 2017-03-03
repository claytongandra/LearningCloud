using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LearningCloud.MVC.Controllers
{
    public static class ExternalClaimsManager
    {
        static Dictionary<string, ExternalClaimReader> _externalPrvdrMngrs = new Dictionary<string, ExternalClaimReader>()
                            {
                                {"Facebook", new FacebookExternalClaimReader()},
                                {"Google", new GoogleExternalClaimReader()},
                                {"Twitter", new TwitterExternalClaimReader()},
                                {"Microsoft", new MicrosoftExternalClaimReader()}
                            };

        static ExternalClaimsManager()
        {

        }

        public class AddtionalLoginDetail
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailAddress { get; set; }


            public AddtionalLoginDetail()
            {

            }
        }


        public async static Task<AddtionalLoginDetail> GetAddtionalLoginDetailsAsync(string loginProvider, Task<ClaimsIdentity> claimsIdentityTask)
        {
            return await _externalPrvdrMngrs[loginProvider].GetAddtionalLoginDetailsAsync(claimsIdentityTask);
        }

        private abstract class ExternalClaimReader
        {
            public abstract Task<AddtionalLoginDetail> GetAddtionalLoginDetailsAsync(Task<ClaimsIdentity> claimsIdentityTask);
            protected string GetClaimValue(IEnumerable<Claim> claims, string claimTypeName)
            {
                if (claims == null) throw new ArgumentNullException("claims");
                if (claimTypeName == null) throw new ArgumentNullException("claimTypeName");

                var value = String.Empty;

                try
                {
                    var claim = claims.First(x => x.Type.Contains(claimTypeName));
                    if (claim != null)
                        value = claim.Value;
                }
                catch (InvalidOperationException) { }

                return value;
            }
        }

        private class FacebookExternalClaimReader : ExternalClaimReader
        {
            public override async Task<AddtionalLoginDetail> GetAddtionalLoginDetailsAsync(Task<ClaimsIdentity> claimsIdentityTask)
            {
                return await Task.Run(() =>
                {
                    var claims = claimsIdentityTask.Result.Claims;

                    var ald = new AddtionalLoginDetail
                    {
                        
                        FirstName = GetClaimValue(claims, "first_name"),// firstName,
                        LastName = GetClaimValue(claims, "last_name"),//lastName,
                        EmailAddress = GetClaimValue(claims, "emailaddress")
    
                     };

                    return ald;
                }
                );
            }
        }

        private class GoogleExternalClaimReader : ExternalClaimReader
        {
            public override async Task<AddtionalLoginDetail> GetAddtionalLoginDetailsAsync(Task<ClaimsIdentity> claimsIdentityTask)
            {
                return await Task.Run(() =>
                {
                    var claims = claimsIdentityTask.Result.Claims;

                    var ald = new AddtionalLoginDetail
                    {
                        EmailAddress = GetClaimValue(claims, ClaimTypes.Email),
                        FirstName = GetClaimValue(claims, ClaimTypes.GivenName),
                        LastName = GetClaimValue(claims, ClaimTypes.Surname)
        

                       

                    };

                    return ald;
                }
                );
            }
        }

        private class TwitterExternalClaimReader : ExternalClaimReader
        {
            public override async Task<AddtionalLoginDetail> GetAddtionalLoginDetailsAsync(Task<ClaimsIdentity> claimsIdentityTask)
            {
                return await Task.Run(() =>
                {
                    var claims = claimsIdentityTask.Result.Claims;

                    var ald = new AddtionalLoginDetail
                    {
                        EmailAddress = GetClaimValue(claims, "urn:twitter:name")
                    };

                    return ald;
                }
                );
            }
        }

        private class MicrosoftExternalClaimReader : ExternalClaimReader
        {
            public override async Task<AddtionalLoginDetail> GetAddtionalLoginDetailsAsync(Task<ClaimsIdentity> claimsIdentityTask)
            {
                return await Task.Run(() =>
                {
                    var claims = claimsIdentityTask.Result.Claims;

                    var firstName = String.Empty;
                    var lastName = String.Empty;
                    var name = GetClaimValue(claims, "urn:microsoft:name");

                    if (!String.IsNullOrEmpty(name))
                    {
                        var names = name.Split(' ');

                        firstName = names[0];
                        lastName = String.Join(" ", names.Skip(1));
                    }

                    var ald = new AddtionalLoginDetail
                    {
                        EmailAddress = GetClaimValue(claims, "emailaddress"),
                        FirstName = firstName,
                        LastName = lastName
                    };

                    var birthdayString = GetClaimValue(claims, "birthday");
                    if (!String.IsNullOrEmpty(birthdayString))
                    {
                        var birthday = DateTime.ParseExact(((string)birthdayString.ToString()), "mm/dd/yyyy", null);
                        //ald.DobDay = birthday.Day;
                        //ald.DobMonth = birthday.Month;
                    }

                    return ald;
                }
                );
            }
        }
    }
}