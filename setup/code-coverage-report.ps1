$coverletOutputPath = '../../../coverage-results'

dotnet tool restore

dotnet test "../src/Krafted/Krafted.slnx" `
/p:CollectCoverage=true `
/p:CoverletOutput="$coverletOutputPath/" `
/p:MergeWith="$coverletOutputPath/coverage.json" `
/p:ExcludeByAttribute="GeneratedCodeAttribute%2cCompilerGeneratedAttribute" `
/p:SkipAutoProps=true `
/p:CoverletOutputFormat="opencover%2cjson" `
-m:1 `
/p:Threshold=93 `
/p:ThresholdStat=average

dotnet reportgenerator -reports:"../coverage-results/coverage.*.opencover.xml" -targetdir:"../coverage-results/report"
