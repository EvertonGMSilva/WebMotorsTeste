#language:pt-br

Funcionalidade: 1- Automação WebMotors
	

Esquema do Cenário: 1.1_Validação de Campos
	Dado que estou na home da WebMotors
	E faço a busca de uma <marca> de carro
	E valido o filtro da marca
	Quando filtro o <modelo> do carro
	E valido o filtro do modelo
	Então valido que a busca foi feita com sucesso

	Exemplos:
	| marca | modelo |
	| Honda | CITY   |

Esquema do Cenário: 1.2_Erro de pesquisa
	Dado que estou na home da WebMotors
	Quando faço a busca "EVERTON" 
	Então valido a <mensagem> de erro

	Exemplos:
	| mensagem                                           |
	| Não encontramos este termo, verifique a ortografia |

