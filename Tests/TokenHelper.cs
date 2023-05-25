using System;
using Common.Backend;

namespace Common.Tests;

public static class TokenHelper
{
    public static TokenSettings Settings = new TokenSettings
    {
        Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==",
        PublicKey = @"-----BEGIN PUBLIC KEY-----
                 MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDTGvumTtnGD5S+xw6oH3LOuysp
                 j6s4KDo6fsbGGAzp8Jb2PBRd/Ree0+FtzNQoVaDka2uCocnuX8+YTpv6J7zDN0zB
                 YWuqBmQVW+5FTjPGkdKwgchzTGLdPtzdUllgqkaDdogBCcyBq6cnDT2U5q1p1j5e
                 +Pnzt4gXGnBoETBzpwIDAQAB
                 -----END PUBLIC KEY-----",

        PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
         MIICXwIBAAKBgQDTGvumTtnGD5S+xw6oH3LOuyspj6s4KDo6fsbGGAzp8Jb2PBRd
         /Ree0+FtzNQoVaDka2uCocnuX8+YTpv6J7zDN0zBYWuqBmQVW+5FTjPGkdKwgchz
         TGLdPtzdUllgqkaDdogBCcyBq6cnDT2U5q1p1j5e+Pnzt4gXGnBoETBzpwIDAQAB
         AoGBAIIGhqWCv6O8iROQq7hl1mL66bTppr4qGONanrf4rEuTQohbrPfPIbNUMe9d
         T/ef9j964ndNi4DlRoo7MNs9iodcqX8KMnNXOlV9iBi+7mpe8jmHC5ZGAoTGnPt5
         vNXPAGtWbSuan8dDkFbbAikmtzIUJdlhj60sU9Q7vpYacI6xAkEA7BcCDQ8JyQNg
         gSKgyyN5T/Rzdj68B1JOVvZtVoQLtyf84XK4E4uUTJ2U+3FNr0FtCV3qK7B6IQbv
         QfOMzbsBRQJBAOTolIXvE+Gci3SDyU0zRp1uAggEdnUX/6vul7fLcPT0+9COD7H6
         2WKxYGDDAVXI9KyO/YNe+DYwYXi0wW64MfsCQQCN9ofVMmW/6bft7tShUgNwgJ2t
         TKvj+yoAQM4eZ+hjijgVmNX3ascSCu+7Araj28OlDkPxYX0Ovwy/q6PPUdPBAkEA
         4jK2OZdjhQkFgVCNBj2KJR1E4plOWS0q18JAqD1f1J+ViqQm/FAOqoju3Q817YhT
         x4TRHRUmn521Y+ryTi+0KwJBAK4D7P7sKAiUYS/Q9TXv1KqW76Vv8JaPDSkhu8bW
         JYmM7mkwoUEEkV7v4Zkp74rmiG+9wmOxBsAjEcHl/IC7Pac=
         -----END RSA PRIVATE KEY-----",
        ExpireMinutes = 3000,
    };
}