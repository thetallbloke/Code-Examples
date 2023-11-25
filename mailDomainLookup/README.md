# Mail Domain Lookup
This came about because we were trying to do some domain discovery exercise with a list of email domains.
We wanted to find out if the domain was still active/correct, and if it was, where the mail was hosted: Google, Microsoft, other.
We would then use this information to determine which "Login with..." button to show on the website.

## Versions
1. Powershell
2. Net v8.0

## Usage

Both use the same input file format, a lookupDomains.txt file with one domain per line, with results displayed in the console window and piped to a results.txt file.
