SELECT r.DTEXAME, r.id_paciente,PACIENTE.NOME, r.id_exame, EXAME.NOME, CONVENIO.NOME, r.TIPO, r.VALOR 
                                          FROM [EXAME], [PACIENTE], [CONVENIO], [REQ_EXAME] r
                                          WHERE (r.id_paciente = PACIENTE.Id) and 
                                                (r.CONVENIO = CONVENIO.id) and
												(r.id_exame = EXAME.Id);

SELECT *
                                          FROM [REQ_EXAME] r, [EXAME], [PACIENTE], [CONVENIO]
                                          WHERE (r.id_paciente = PACIENTE.Id) and 
                                                (r.CONVENIO = CONVENIO.id) and
												(r.id_exame = EXAME.Id);
SELECT * FROM REQ_EXAME R JOIN EXAME E ON R.id_exame = E.Id 
						  JOIN PACIENTE P ON R.id_paciente = P.Id
						  JOIN CONVENIO C ON R.CONVENIO = C.Id
                                 
SELECT * FROM REQ_EXAME R JOIN EXAME E ON R.id_exame = E.Id 
						  JOIN PACIENTE P ON R.id_paciente = P.Id
						  JOIN CONVENIO C ON R.CONVENIO = C.Id;