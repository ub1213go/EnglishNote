using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encrypt
{
    public class JWTService
    {
        public int expireMinute { get; set; }
        public string secret { get; set; }
        public IJwtAlgorithm algorithm { get; set; }
        public IJsonSerializer serializer { get; set; }
        public IDateTimeProvider provider { get; set; }
        public IJwtValidator validator { get; set; }
        public IBase64UrlEncoder urlEncoder { get; set; }
        public IJwtEncoder encoder { get; set; }
        public IJwtDecoder decoder { get; set; }

        public JWTService(string _secret)
        {
            expireMinute = 5;
            secret = _secret;

            algorithm = new HMACSHA256Algorithm();
            serializer = new JsonNetSerializer();
            provider = new UtcDateTimeProvider();
            validator = new JwtValidator(serializer, provider);
            urlEncoder = new JwtBase64UrlEncoder();
            encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
        }

        public string getJWT()
        {
            double exp = (DateTime.UtcNow.AddMinutes(expireMinute) - new DateTime(1970, 1, 1)).TotalSeconds;
            var payload = new Dictionary<string, object>
            {
                {"employeeWorkCode", "111113" },
                {"employeeName", "明倫"},
                {"groupNo", "APSteam" },
                {"exp", exp }
            };

            var token = encoder.Encode(payload, secret);
            return token;
        }

        public string varifyJWT(string token)
        {
            var json = decoder.Decode(token, secret, verify:true);

            return json;
        }
    }
}
