SELECT
    assunto AS ASSUNTO,
    ano AS ANO,
    COUNT(*) AS QUANTIDADE
FROM
    atendimentos
GROUP BY
    assunto,
    ano
HAVING
    QUANTIDADE > 3
ORDER BY
    ANO DESC,
    QUANTIDADE DESC;