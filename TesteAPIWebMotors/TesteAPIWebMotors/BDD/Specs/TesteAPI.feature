#language:pt-BR

Funcionalidade:1 TesteAPI


Esquema do Cenário: 1.1_API MARCA
	Quando faco a requisicao usando o <ID> para buscar a marca
	Entao valido o <RESULTADO> de busca na API

	Exemplos: 
	| ID | RESULTADO |
	| 0  | Chevrolet |
	| 1  | Honda     |
	| 2  | Ford      |

Esquema do Cenário: 1.2_API MODELO
	Quando faco a requisicao usando o <MakeID> para buscar o modelo pelo <parametro>
	Entao valido o <modelo> e o <id> do carro

	Exemplos: 
	| MakeID | modelo | parametro | id |
	| 1      | Agile  | 0         | 1  |
	| 1      | Astra  | 1         | 2  |
	| 1      | Onix   | 2         | 3  |

Esquema do Cenário: 1.3_API VERSAO
	Quando faco a requisicao usando o <ModelID> para buscar a versao pelo <parametro>
	Entao valido o <versao> e o <id> do carro	

	Exemplos: 
	| ModelID | versao                                           | parametro | id |
	| 2       | 1.5 DX 16V FLEX 4P AUTOMÁTICO                    | 0         | 11 |
	| 2       | 1.5 LX 16V FLEX 4P MANUAL                        | 1         | 12 |
	| 2       | 2.0 EXL 4X4 16V GASOLINA 4P AUTOMÁTICO           | 2         | 13 |
	| 2       | 1.8 16V EVO FLEX FREEDOM OPEN EDITION AUTOMÁTICO | 3         | 14 |
	| 2       | 1.0 MPI EL 8V FLEX 4P MANUAL                     | 4         | 15 |

Esquema do Cenário: 1.4_API VERSAO_2
	Quando faco a requisicao usando o <ModelID> para buscar a nova versao pelo <parametro>
	Entao valido o <versao>,<marca>,<modelo> e o <id>

	Exemplos: 
	| ModelID | versao                                  | marca      | modelo | parametro | id |
	| 2       | 2.0 EVO 4P AUTOMÁTICO                   | Mitsubishi | Lancer | 0         | 11 |
	| 2       | 1.4 LXL 16V FLEX 4P AUTOMÁTICO          | Honda      | Fit    | 1         | 12 |
	| 2       | 1.4 MPFI EFFECT 8V FLEX 4P AUTOMATIZADO | Chevrolet  | Agile  | 2         | 13 |
	| 2       | 1.4 LXL 16V FLEX 4P AUTOMÁTICO          | Honda      | Fit    | 3         | 14 |
	| 2       | 2.0 EXL 4X4 16V GASOLINA 4P AUTOMÁTICO  | Honda      | City   | 4         | 15 |
	| 2       | 2.0 EVO 4P AUTOMÁTICO                   | Mitsubishi | Lancer | 5         | 16 |
	| 2       | 1.4 LXL 16V FLEX 4P AUTOMÁTICO          | Honda      | Fit    | 6         | 17 |
	| 2       | 2.0 EVO 4P AUTOMÁTICO                   | Mitsubishi | Lancer | 7         | 18 |
	| 2       | 1.4 LXL 16V FLEX 4P AUTOMÁTICO          | Honda      | Fit    | 8         | 19 |
	| 2       | 1.4 MPFI EFFECT 8V FLEX 4P AUTOMATIZADO | Chevrolet  | Agile  | 9         | 20 |