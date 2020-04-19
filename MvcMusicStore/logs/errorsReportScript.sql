SELECT 
    Text AS Errors
INTO Report.CSV
FROM %file%
WHERE Text LIKE '%ERROR%'