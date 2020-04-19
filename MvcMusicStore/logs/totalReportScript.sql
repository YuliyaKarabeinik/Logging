SELECT 
    TRIM(SUBSTR(text, 25, 5)), 
    COUNT([Index])
INTO Report.CSV
FROM %file%
WHERE (CASE TRIM(SUBSTR(text, 25, 5)) 
        WHEN 'ERROR' THEN 1 
        WHEN 'DEBUG' THEN 1
        WHEN 'INFO' THEN 1
        ELSE 2
        END = 1)
GROUP BY TRIM(SUBSTR(text, 25, 5))
