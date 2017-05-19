SELECT * FROM REQ_EXAME R JOIN EXAME E ON R.id_exame = E.Id 
						  JOIN PACIENTE P ON R.id_paciente = P.Id
						  FULL OUTER JOIN CONVENIO C ON R.CONVENIO = C.Id						  
		 WHERE R.id_paciente is not null
		 order by 3 desc;
