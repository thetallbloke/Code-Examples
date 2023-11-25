Clear-Host
$resultsFile = "results.txt"
$domainList = "lookupDomains.txt"

if (Test-Path $resultsFile) {
    Remove-Item $resultsFile
}

$domains = @()  # Add your list of domains here

# Read domains from file and append to $domains array
if (Test-Path $domainList) {
    $domains += Get-Content $domainList
    Write-Host "Reading domains from $domainList - $($domains.Count) domains found"
}

foreach ($domain in $domains) {
    $mxRecords = Resolve-DnsName -Name $domain -Type MX

    $mailServers = $mxRecords | Where-Object QueryType -eq "MX" | ForEach-Object { $_.NameExchange }

    $paddedDomain = $domain.PadRight(22, ' ')
    $provider = ""

    if ($mailServers | Where-Object { $_ -like "*google.com*" }) { $provider = "Google" }
    elseif ($mailServers | Where-Object { $_ -like "*outlook.com*" -or $_ -like "*hotmail.com*" -or $_ -like "*live.com*" -or $_ -like "*.mail.protection.outlook.com*" }) { $provider = "Microsoft" }
    elseif ($mailServers | Where-Object { $_ -like "*mxrecord.io*" }) { $provider = "??????????" }
    else { $provider = "Other" }

    $paddedProvider = $provider.PadRight(12, ' ')
    "$paddedDomain -- $paddedProvider $mailServers" | Tee-Object -Append -FilePath $resultsFile
}

Write-Host "Done. Results saved to $resultsFile"
