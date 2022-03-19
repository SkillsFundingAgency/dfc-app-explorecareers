Feature: ExploreCareersCUIcounts
		I want to reconcile counts between the production environment and the test environment

Scenario Outline: Compare Job profile search counts in different environments
	Given I am at the "Search results" page
	And I search for the term <Job profile>
	And I note the number of search results
	And I surf to the "Production" environments "search results" page
	And I search for the term <Job profile>
	And I note the number of search results
	When I compare the number of search results noted from both environments
	Then the number is the same
Examples:
	| no. | Job profile                                                   | Job category                      |
	| 1   | Admin assistant                                               | Administrator                     |
	| 2   | Arts administrator                                            | Administrator                     |
	| 3   | Assistant immigration officer                                 | Administrator                     |
	| 4   | Auditor                                                       | Administrator                     |
	| 5   | Bid writer                                                    | Administrator                     |
	| 6   | Bilingual secretary                                           | Administrator                     |
	| 7   | Bookkeeper                                                    | Administrator                     |
	| 8   | Border Force officer                                          | Administrator                     |
	| 9   | Car rental agent                                              | Administrator                     |
	| 10  | Charity fundraiser                                            | Administrator                     |
	| 11  | Civil Service administrative officer                          | Administrator                     |
	| 12  | Civil Service executive officer                               | Administrator                     |
	| 13  | Credit controller                                             | Administrator                     |
	| 14  | Data entry clerk                                              | Administrator                     |
	| 15  | Diplomatic Service officer                                    | Administrator                     |
	| 16  | Estates officer                                               | Administrator                     |
	| 17  | Farm secretary                                                | Administrator                     |
	| 18  | Finance officer                                               | Administrator                     |
	| 19  | Financial services customer adviser                           | Administrator                     |
	| 20  | GP practice manager                                           | Administrator                     |
	| 21  | Health and safety adviser                                     | Administrator                     |
	| 22  | Health records clerk                                          | Administrator                     |
	| 23  | Health service manager                                        | Administrator                     |
	| 24  | Human resources officer                                       | Administrator                     |
	| 25  | Immigration officer                                           | Administrator                     |
	| 26  | Import-export clerk                                           | Administrator                     |
	| 27  | Insurance broker                                              | Administrator                     |
	| 28  | Insurance technician                                          | Administrator                     |
	| 29  | Interpreter                                                   | Administrator                     |
	| 30  | Local government administrative assistant                     | Administrator                     |
	| 31  | Local government officer                                      | Administrator                     |
	| 32  | Local government revenues officer                             | Administrator                     |
	| 33  | Medical secretary                                             | Administrator                     |
	| 34  | Office manager                                                | Administrator                     |
	| 35  | Payroll administrator                                         | Administrator                     |
	| 36  | Personal assistant                                            | Administrator                     |
	| 37  | Post Office customer service assistant                        | Administrator                     |
	| 38  | Proofreader                                                   | Administrator                     |
	| 39  | Purchasing manager                                            | Administrator                     |
	| 40  | Quality control assistant                                     | Administrator                     |
	| 41  | Receptionist                                                  | Administrator                     |
	| 42  | Recruitment consultant                                        | Administrator                     |
	| 43  | Registrar of births, deaths, marriages and civil partnerships | Administrator                     |
	| 44  | Reprographic assistant                                        | Administrator                     |
	| 45  | Sales administrator                                           | Administrator                     |
	| 46  | School business manager                                       | Administrator                     |
	| 47  | School secretary                                              | Administrator                     |
	| 48  | Secretary                                                     | Administrator                     |
	| 49  | Security Service personnel                                    | Administrator                     |
	| 50  | Sports development officer                                    | Administrator                     |
	| 51  | Supervisor                                                    | Administrator                     |
	| 52  | Telephonist                                                   | Administrator                     |
	| 53  | Town planning assistant                                       | Administrator                     |
	| 54  | Trade union official                                          | Administrator                     |
	| 55  | Trading standards officer                                     | Administrator                     |
	| 56  | Agricultural contractor                                       | Animal care                       |
	| 57  | Agricultural inspector                                        | Animal care                       |
	| 58  | worker                                                        | Animal care                       |
	| 59  | Animal technician                                             | Animal care                       |
	| 60  | Dog training and behaviour adviser                            | Animal care                       |
	| 61  | Beekeeper                                                     | Animal care                       |
	| 62  | Biologist                                                     | Animal care                       |
	| 63  | Countryside ranger                                            | Animal care                       |
	| 64  | Dog groomer                                                   | Animal care                       |
	| 65  | Dog handler                                                   | Animal care                       |
	| 66  | Ecologist                                                     | Animal care                       |
	| 67  | Farm worker                                                   | Animal care                       |
	| 68  | Farmer                                                        | Animal care                       |
	| 69  | Farrier                                                       | Animal care                       |
	| 70  | Fish farmer                                                   | Animal care                       |
	| 71  | Fishing boat deckhand                                         | Animal care                       |
	| 72  | Gamekeeper                                                    | Animal care                       |
	| 73  | Horse groom                                                   | Animal care                       |
	| 74  | Horse riding instructor                                       | Animal care                       |
	| 75  | Jockey                                                        | Animal care                       |
	| 76  | Kennel worker                                                 | Animal care                       |
	| 77  | Pet behaviour consultant                                      | Animal care                       |
	| 78  | Pet shop assistant                                            | Animal care                       |
	| 79  | RSPCA inspector                                               | Animal care                       |
	| 80  | Racehorse trainer                                             | Animal care                       |
	| 81  | Vet                                                           | Animal care                       |
	| 82  | Veterinary nurse                                              | Animal care                       |
	| 83  | Veterinary physiotherapist                                    | Animal care                       |
	| 84  | Zookeeper                                                     | Animal care                       |
	| 85  | Zoologist                                                     | Animal care                       |
	| 86  | Local government administrative assistant                     | Animal care                       |
	| 87  | Local government officer                                      | Animal care                       |
	| 88  | Local government revenues officer                             | Animal care                       |
	| 89  | Medical secretary                                             | Animal care                       |
	| 90  | Office manager                                                | Animal care                       |
	| 91  | Payroll administrator                                         | Animal care                       |
	| 92  | Personal assistant                                            | Animal care                       |
	| 93  | Post Office customer service assistant                        | Animal care                       |
	| 94  | Proofreader                                                   | Animal care                       |
	| 95  | Purchasing manager                                            | Animal care                       |
	| 96  | Quality control assistant                                     | Animal care                       |
	| 97  | Receptionist                                                  | Animal care                       |
	| 98  | Recruitment consultant                                        | Animal care                       |
	| 99  | Registrar of births, deaths, marriages and civil partnerships | Animal care                       |
	| 100 | Reprographic assistant                                        | Animal care                       |
	| 101 | Sales administrator                                           | Animal care                       |
	| 102 | School business manager                                       | Animal care                       |
	| 103 | School secretary                                              | Animal care                       |
	| 104 | Secretary                                                     | Animal care                       |
	| 105 | Security Service personnel                                    | Animal care                       |
	| 106 | Sports development officer                                    | Animal care                       |
	| 107 | Supervisor                                                    | Animal care                       |
	| 108 | Telephonist                                                   | Animal care                       |
	| 109 | Town planning assistant                                       | Animal care                       |
	| 110 | Trade union official                                          | Animal care                       |
	| 111 | Trading standards officer                                     | Animal care                       |
	| 112 | Acupuncturist                                                 | Beauty and wellbeing              |
	| 113 | Aromatherapist                                                | Beauty and wellbeing              |
	| 114 | Art therapist                                                 | Beauty and wellbeing              |
	| 115 | Barber                                                        | Beauty and wellbeing              |
	| 116 | Beauty consultant                                             | Beauty and wellbeing              |
	| 117 | Beauty therapist                                              | Beauty and wellbeing              |
	| 118 | Chiropractor                                                  | Beauty and wellbeing              |
	| 119 | Counsellor                                                    | Beauty and wellbeing              |
	| 120 | Dance movement psychotherapist                                | Beauty and wellbeing              |
	| 121 | Dramatherapist                                                | Beauty and wellbeing              |
	| 122 | Hairdresser                                                   | Beauty and wellbeing              |
	| 123 | Health play specialist                                        | Beauty and wellbeing              |
	| 124 | Homeopath                                                     | Beauty and wellbeing              |
	| 125 | Massage therapist                                             | Beauty and wellbeing              |
	| 126 | Medical herbalist                                             | Beauty and wellbeing              |
	| 127 | Music therapist                                               | Beauty and wellbeing              |
	| 128 | Nail technician                                               | Beauty and wellbeing              |
	| 129 | Naturopath                                                    | Beauty and wellbeing              |
	| 130 | Nutritional therapist                                         | Beauty and wellbeing              |
	| 131 | Osteopath                                                     | Beauty and wellbeing              |
	| 132 | Pilates teacher                                               | Beauty and wellbeing              |
	| 133 | Reflexologist                                                 | Beauty and wellbeing              |
	| 134 | Reiki healer                                                  | Beauty and wellbeing              |
	| 135 | Tattooist and body piercer                                    | Beauty and wellbeing              |
	| 136 | Yoga therapist                                                | Beauty and wellbeing              |
	| 137 | Accounting technician                                         | Business and finance              |
	| 138 | Actuary                                                       | Business and finance              |
	| 139 | Auditor                                                       | Business and finance              |
	| 140 | Bank manager                                                  | Business and finance              |
	| 141 | Banking customer service adviser                              | Business and finance              |
	| 142 | Bookkeeper                                                    | Business and finance              |
	| 143 | Business adviser                                              | Business and finance              |
	| 144 | Business development manager                                  | Business and finance              |
	| 145 | Business project manager                                      | Business and finance              |
	| 146 | Chief executive                                               | Business and finance              |
	| 147 | Company secretary                                             | Business and finance              |
	| 148 | Corporate responsibility and sustainability practitioner      | Business and finance              |
	| 149 | Credit controller                                             | Business and finance              |
	| 150 | Credit manager                                                | Business and finance              |
	| 151 | Economist                                                     | Business and finance              |
	| 152 | Finance officer                                               | Business and finance              |
	| 153 | Financial adviser                                             | Business and finance              |
	| 154 | Financial services customer adviser                           | Business and finance              |
	| 155 | Insurance account manager                                     | Business and finance              |
	| 156 | Insurance broker                                              | Business and finance              |
	| 157 | Insurance claims handler                                      | Business and finance              |
	| 158 | Insurance loss adjuster                                       | Business and finance              |
	| 159 | Insurance risk surveyor                                       | Business and finance              |
	| 160 | Insurance technician                                          | Business and finance              |
	| 161 | Insurance underwriter                                         | Business and finance              |
	| 162 | Investment analyst                                            | Business and finance              |
	| 163 | Local government revenues officer                             | Business and finance              |
	| 164 | Management accountant                                         | Business and finance              |
	| 165 | Market research executive                                     | Business and finance              |
	| 166 | Marketing manager                                             | Business and finance              |
	| 167 | Money adviser                                                 | Business and finance              |
	| 168 | Mortgage adviser                                              | Business and finance              |
	| 169 | Payroll administrator                                         | Business and finance              |
	| 170 | Payroll manager                                               | Business and finance              |
	| 171 | Pensions administrator                                        | Business and finance              |
	| 172 | Pensions adviser                                              | Business and finance              |
	| 173 | Private practice accountant                                   | Business and finance              |
	| 174 | Public finance accountant                                     | Business and finance              |
	| 175 | School business manager                                       | Business and finance              |
	| 176 | Stockbroker                                                   | Business and finance              |
	| 177 | Tax adviser                                                   | Business and finance              |
	| 178 | Tax inspector                                                 | Business and finance              |
	| 179 | 3D printing technician                                        | Computing, technology and digital |
	| 180 | App developer                                                 | Computing, technology and digital |
	| 181 | Archivist                                                     | Computing, technology and digital |
	| 182 | Business analyst                                              | Computing, technology and digital |
	| 183 | Cartographer                                                  | Computing, technology and digital |
	| 184 | Computer games developer                                      | Computing, technology and digital |
	| 185 | Computer games tester                                         | Computing, technology and digital |
	| 186 | Cyber intelligence officer                                    | Computing, technology and digital |
	| 187 | Data entry clerk                                              | Computing, technology and digital |
	| 188 | Data scientist                                                | Computing, technology and digital |
	| 189 | Database administrator                                        | Computing, technology and digital |
	| 190 | Digital delivery manager                                      | Computing, technology and digital |
	| 191 | Digital product owner                                         | Computing, technology and digital |
	| 192 | E-learning developer                                          | Computing, technology and digital |
	| 193 | Forensic computer analyst                                     | Computing, technology and digital |
	| 194 | Geospatial technician                                         | Computing, technology and digital |
	| 195 | IT project manager                                            | Computing, technology and digital |
	| 196 | IT security co-ordinator                                      | Computing, technology and digital |
	| 197 | IT support technician                                         | Computing, technology and digital |
	| 198 | IT trainer                                                    | Computing, technology and digital |
	| 199 | Indexer                                                       | Computing, technology and digital |
	| 200 | Information scientist                                         | Computing, technology and digital |
	| 201 | Librarian                                                     | Computing, technology and digital |
	| 202 | Library assistant                                             | Computing, technology and digital |
	| 203 | Media researcher                                              | Computing, technology and digital |
	| 204 | Network engineer                                              | Computing, technology and digital |
	| 205 | Network manager                                               | Computing, technology and digital |
	| 206 | Operational researcher                                        | Computing, technology and digital |
	| 207 | Pre-press operator                                            | Computing, technology and digital |
	| 208 | Robotics engineer                                             | Computing, technology and digital |
	| 209 | Security Service personnel                                    | Computing, technology and digital |
	| 210 | Social media manager                                          | Computing, technology and digital |
	| 211 | Software developer                                            | Computing, technology and digital |
	| 212 | Solutions architect                                           | Computing, technology and digital |
	| 213 | Systems analyst                                               | Computing, technology and digital |
	| 214 | Technical architect                                           | Computing, technology and digital |
	| 215 | Technical author                                              | Computing, technology and digital |
	| 216 | Telephonist                                                   | Computing, technology and digital |
	| 217 | Test lead                                                     | Computing, technology and digital |
	| 218 | User experience (UX) designer                                 | Computing, technology and digital |
	| 219 | User researcher                                               | Computing, technology and digital |
	| 220 | Vlogger                                                       | Computing, technology and digital |
	| 221 | Web content editor                                            | Computing, technology and digital |
	| 222 | Web content manager                                           | Computing, technology and digital |
	| 223 | Web designer                                                  | Computing, technology and digital |
	| 224 | Web developer                                                 | Computing, technology and digital |