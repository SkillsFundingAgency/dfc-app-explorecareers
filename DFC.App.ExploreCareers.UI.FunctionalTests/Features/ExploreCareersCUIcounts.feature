Feature: ExploreCareersCUIcounts
		I want to reconcile counts between the production environment and the test environment

Scenario Outline: TCB01 - Compare Job profile search result counts in different environments
	Given I am at the "Search results" page
	And I search for the term <Job profile> of the <Job category> Job category
	And I note the number of search results
	And I surf to the "Production" environments "search results" page
	And I search for the term <Job profile> of the <Job category> Job category
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
	| 225 | Acoustics consultant                                          | Construction and trades           |
	| 226 | Architect                                                     | Construction and trades           |
	| 227 | Architectural technician                                      | Construction and trades           |
	| 228 | Architectural technologist                                    | Construction and trades           |
	| 229 | Boat builder                                                  | Construction and trades           |
	| 230 | Bricklayer                                                    | Construction and trades           |
	| 231 | Builders' merchant                                            | Construction and trades           |
	| 232 | Building control officer                                      | Construction and trades           |
	| 233 | Building services engineer                                    | Construction and trades           |
	| 234 | Building site inspector                                       | Construction and trades           |
	| 235 | Building surveyor                                             | Construction and trades           |
	| 236 | Building technician                                           | Construction and trades           |
	| 237 | CAD technician                                                | Construction and trades           |
	| 238 | Carpenter                                                     | Construction and trades           |
	| 239 | Carpet fitter and floor layer                                 | Construction and trades           |
	| 240 | Cavity insulation installer                                   | Construction and trades           |
	| 241 | Ceiling fixer                                                 | Construction and trades           |
	| 242 | Civil engineer                                                | Construction and trades           |
	| 243 | Civil engineering technician                                  | Construction and trades           |
	| 244 | Commercial energy assessor                                    | Construction and trades           |
	| 245 | Construction contracts manager                                | Construction and trades           |
	| 246 | Construction labourer                                         | Construction and trades           |
	| 247 | Construction manager                                          | Construction and trades           |
	| 248 | Construction plant hire adviser                               | Construction and trades           |
	| 249 | Construction plant mechanic                                   | Construction and trades           |
	| 250 | Construction plant operator                                   | Construction and trades           |
	| 251 | Construction site supervisor                                  | Construction and trades           |
	| 252 | Crane driver                                                  | Construction and trades           |
	| 253 | Demolition operative                                          | Construction and trades           |
	| 254 | Domestic energy assessor                                      | Construction and trades           |
	| 255 | Dry liner                                                     | Construction and trades           |
	| 256 | Electrician                                                   | Construction and trades           |
	| 257 | Electricity distribution worker                               | Construction and trades           |
	| 258 | Engineering construction craftworker                          | Construction and trades           |
	| 259 | Engineering construction technician                           | Construction and trades           |
	| 260 | Estimator                                                     | Construction and trades           |
	| 261 | Facilities manager                                            | Construction and trades           |
	| 262 | Fence installer                                               | Construction and trades           |
	| 263 | Gas mains layer                                               | Construction and trades           |
	| 264 | Gas service technician                                        | Construction and trades           |
	| 265 | General practice surveyor                                     | Construction and trades           |
	| 266 | Glazier                                                       | Construction and trades           |
	| 267 | Heating and ventilation engineer                              | Construction and trades           |
	| 268 | Heritage officer                                              | Construction and trades           |
	| 269 | Kitchen and bathroom fitter                                   | Construction and trades           |
	| 270 | Land and property valuer and auctioneer                       | Construction and trades           |
	| 271 | Land surveyor                                                 | Construction and trades           |
	| 272 | Landscaper                                                    | Construction and trades           |
	| 273 | Mechanical engineering technician                             | Construction and trades           |
	| 274 | Paint sprayer                                                 | Construction and trades           |
	| 275 | Painter and decorator                                         | Construction and trades           |
	| 276 | Pipe fitter                                                   | Construction and trades           |
	| 277 | Planning and development surveyor                             | Construction and trades           |
	| 278 | Plasterer                                                     | Construction and trades           |
	| 279 | Plumber                                                       | Construction and trades           |
	| 280 | Quantity surveyor                                             | Construction and trades           |
	| 281 | Quarry engineer                                               | Construction and trades           |
	| 282 | Quarry worker                                                 | Construction and trades           |
	| 283 | Refrigeration and air-conditioning installer                  | Construction and trades           |
	| 284 | Road worker                                                   | Construction and trades           |
	| 285 | Roofer                                                        | Construction and trades           |
	| 286 | Rural surveyor                                                | Construction and trades           |
	| 287 | Scaffolder                                                    | Construction and trades           |
	| 288 | Shopfitter                                                    | Construction and trades           |
	| 289 | Steel erector                                                 | Construction and trades           |
	| 290 | Steel fixer                                                   | Construction and trades           |
	| 291 | Steeplejack                                                   | Construction and trades           |
	| 292 | Stonemason                                                    | Construction and trades           |
	| 293 | Structural engineer                                           | Construction and trades           |
	| 294 | Technical surveyor                                            | Construction and trades           |
	| 295 | Thatcher                                                      | Construction and trades           |
	| 296 | Thermal insulation engineer                                   | Construction and trades           |
	| 297 | Tiler                                                         | Construction and trades           |
	| 298 | Town planner                                                  | Construction and trades           |
	| 299 | Town planning assistant                                       | Construction and trades           |
	| 300 | Water network operative                                       | Construction and trades           |
	| 301 | Welder                                                        | Construction and trades           |
	| 302 | Window fitter                                                 | Construction and trades           |
	| 303 | Wood machinist                                                | Construction and trades           |
	| 304 | Actor                                                         | Creative and media                |
	| 305 | Advertising account executive                                 | Creative and media                |
	| 306 | Advertising account planner                                   | Creative and media                |
	| 307 | Advertising art director                                      | Creative and media                |
	| 308 | Advertising copywriter                                        | Creative and media                |
	| 309 | Advertising media buyer                                       | Creative and media                |
	| 310 | Advertising media planner                                     | Creative and media                |
	| 311 | Animator                                                      | Creative and media                |
	| 312 | Antique dealer                                                | Creative and media                |
	| 313 | Archivist                                                     | Creative and media                |
	| 314 | Art editor                                                    | Creative and media                |
	| 315 | Art therapist                                                 | Creative and media                |
	| 316 | Art valuer                                                    | Creative and media                |
	| 317 | Arts administrator                                            | Creative and media                |
	| 318 | Audio-visual technician                                       | Creative and media                |
	| 319 | Blacksmith                                                    | Creative and media                |
	| 320 | Bookbinder                                                    | Creative and media                |
	| 321 | Bookseller                                                    | Creative and media                |
	| 322 | Broadcast engineer                                            | Creative and media                |
	| 323 | Broadcast journalist                                          | Creative and media                |
	| 324 | Ceramics designer-maker                                       | Creative and media                |
	| 325 | Choreographer                                                 | Creative and media                |
	| 326 | Commissioning editor                                          | Creative and media                |
	| 327 | Community arts worker                                         | Creative and media                |
	| 328 | Computer games tester                                         | Creative and media                |
	| 329 | Conservator                                                   | Creative and media                |
	| 330 | Copy editor                                                   | Creative and media                |
	| 331 | Costume designer                                              | Creative and media                |
	| 332 | DJ                                                            | Creative and media                |
	| 333 | Dance teacher                                                 | Creative and media                |
	| 334 | Dancer                                                        | Creative and media                |
	| 335 | Design and development engineer                               | Creative and media                |
	| 336 | Director of photography                                       | Creative and media                |
	| 337 | Dressmaker                                                    | Creative and media                |
	| 338 | Drone pilot                                                   | Creative and media                |
	| 339 | Editorial assistant                                           | Creative and media                |
	| 340 | Entertainer                                                   | Creative and media                |
	| 341 | Ergonomist                                                    | Creative and media                |
	| 342 | Exhibition designer                                           | Creative and media                |
	| 343 | Fashion design assistant                                      | Creative and media                |
	| 344 | Fashion designer                                              | Creative and media                |
	| 345 | Fashion model                                                 | Creative and media                |
	| 346 | Film critic                                                   | Creative and media                |
	| 347 | Fine artist                                                   | Creative and media                |
	| 348 | Florist                                                       | Creative and media                |
	| 349 | Footwear designer                                             | Creative and media                |
	| 350 | Franchise owner                                               | Creative and media                |
	| 351 | French polisher                                               | Creative and media                |
	| 352 | Furniture designer                                            | Creative and media                |
	| 353 | Furniture maker                                               | Creative and media                |
	| 354 | Furniture restorer                                            | Creative and media                |
	| 355 | Glassmaker                                                    | Creative and media                |
	| 356 | Graphic designer                                              | Creative and media                |
	| 357 | Illustrator                                                   | Creative and media                |
	| 358 | Indexer                                                       | Creative and media                |
	| 359 | Interior designer                                             | Creative and media                |
	| 360 | Jewellery designer-maker                                      | Creative and media                |
	| 361 | Kitchen and bathroom designer                                 | Creative and media                |
	| 362 | Knitting machinist                                            | Creative and media                |
	| 363 | Landscape architect                                           | Creative and media                |
	| 364 | Leather craftworker                                           | Creative and media                |
	| 365 | Lighting technician                                           | Creative and media                |
	| 366 | Live sound engineer                                           | Creative and media                |
	| 367 | Magazine journalist                                           | Creative and media                |
	| 368 | Make-up artist                                                | Creative and media                |
	| 369 | Market research data analyst                                  | Creative and media                |
	| 370 | Market researcher                                             | Creative and media                |
	| 371 | Marketing executive                                           | Creative and media                |
	| 372 | Marketing manager                                             | Creative and media                |
	| 373 | Media researcher                                              | Creative and media                |
	| 374 | Medical illustrator                                           | Creative and media                |
	| 375 | Model maker                                                   | Creative and media                |
	| 376 | Museum curator                                                | Creative and media                |
	| 377 | Music promotions manager                                      | Creative and media                |
	| 378 | Music teacher                                                 | Creative and media                |
	| 379 | Music therapist                                               | Creative and media                |
	| 380 | Musical instrument maker and repairer                         | Creative and media                |
	| 381 | Musician                                                      | Creative and media                |
	| 382 | Naval architect                                               | Creative and media                |
	| 383 | Newspaper journalist                                          | Creative and media                |
	| 384 | Newspaper or magazine editor                                  | Creative and media                |
	| 385 | Pattern cutter                                                | Creative and media                |
	| 386 | Photographer                                                  | Creative and media                |
	| 387 | Photographic stylist                                          | Creative and media                |
	| 388 | Photographic technician                                       | Creative and media                |
	| 389 | Picture framer                                                | Creative and media                |
	| 390 | Pre-press operator                                            | Creative and media                |
	| 391 | Product designer                                              | Creative and media                |
	| 392 | Prop maker                                                    | Creative and media                |
	| 393 | Public relations director                                     | Creative and media                |
	| 394 | Public relations officer                                      | Creative and media                |
	| 395 | Radio broadcast assistant                                     | Creative and media                |
	| 396 | Reprographic assistant                                        | Creative and media                |
	| 397 | Retail merchandiser                                           | Creative and media                |
	| 398 | Roadie                                                        | Creative and media                |
	| 399 | Sales manager                                                 | Creative and media                |
	| 400 | Screenwriter                                                  | Creative and media                |
	| 401 | Set designer                                                  | Creative and media                |
	| 402 | Sewing machinist                                              | Creative and media                |
	| 403 | Signwriter                                                    | Creative and media                |
	| 404 | Sports commentator                                            | Creative and media                |
	| 405 | Stage manager                                                 | Creative and media                |
	| 406 | Stagehand                                                     | Creative and media                |
	| 407 | Studio sound engineer                                         | Creative and media                |
	| 408 | Sub-editor                                                    | Creative and media                |
	| 409 | TV or film assistant director                                 | Creative and media                |
	| 410 | TV or film assistant production co-ordinator                  | Creative and media                |
	| 411 | TV or film camera operator                                    | Creative and media                |
	| 412 | TV or film director                                           | Creative and media                |
	| 413 | TV or film producer                                           | Creative and media                |
	| 414 | TV or film production manager                                 | Creative and media                |
	| 415 | TV or film production runner                                  | Creative and media                |
	| 416 | TV or film sound technician                                   | Creative and media                |
	| 417 | TV presenter                                                  | Creative and media                |
	| 418 | Tailor                                                        | Creative and media                |
	| 419 | Tattooist and body piercer                                    | Creative and media                |
	| 420 | Taxidermist                                                   | Creative and media                |
	| 421 | Technical author                                              | Creative and media                |
	| 422 | Technical textiles designer                                   | Creative and media                |
	| 423 | Textile designer                                              | Creative and media                |
	| 424 | Textiles production manager                                   | Creative and media                |
	| 425 | Translator                                                    | Creative and media                |
	| 426 | Upholsterer                                                   | Creative and media                |
	| 427 | Video editor                                                  | Creative and media                |
	| 428 | Visual merchandiser                                           | Creative and media                |
	| 429 | Vlogger                                                       | Creative and media                |
	| 430 | Wardrobe assistant                                            | Creative and media                |
	| 431 | Web content editor                                            | Creative and media                |
	| 432 | Web designer                                                  | Creative and media                |
	| 433 | Writer                                                        | Creative and media                |
	| 434 | Airport baggage handler                                       | Delivery and storage              |
	| 435 | Delivery van driver                                           | Delivery and storage              |
	| 436 | Food packaging operative                                      | Delivery and storage              |
	| 437 | Forklift driver                                               | Delivery and storage              |
	| 438 | Import-export clerk                                           | Delivery and storage              |
	| 439 | Large goods vehicle driver                                    | Delivery and storage              |
	| 440 | Motor vehicle parts person                                    | Delivery and storage              |
	| 441 | Order picker                                                  | Delivery and storage              |
	| 442 | Packer                                                        | Delivery and storage              |
	| 443 | Port operative                                                | Delivery and storage              |
	| 444 | Postperson                                                    | Delivery and storage              |
	| 445 | Removals worker                                               | Delivery and storage              |
	| 446 | Road transport manager                                        | Delivery and storage              |
	| 447 | Shelf filler                                                  | Delivery and storage              |
	| 448 | Stock control assistant                                       | Delivery and storage              |
	| 449 | Supply chain manager                                          | Delivery and storage              |
	| 450 | Tanker driver                                                 | Delivery and storage              |
	| 451 | Warehouse manager                                             | Delivery and storage              |
	| 452 | Warehouse worker                                              | Delivery and storage              |
	| 453 | Aid worker                                                    | Emergency and uniform services    |
	| 454 | Army officer                                                  | Emergency and uniform services    |
	| 455 | Bodyguard                                                     | Emergency and uniform services    |
	| 456 | Border Force officer                                          | Emergency and uniform services    |
	| 457 | Chief inspector                                               | Emergency and uniform services    |
	| 458 | Civil enforcement officer                                     | Emergency and uniform services    |
	| 459 | Coastguard                                                    | Emergency and uniform services    |
	| 460 | Diver                                                         | Emergency and uniform services    |
	| 461 | Dog handler                                                   | Emergency and uniform services    |
	| 462 | Door supervisor                                               | Emergency and uniform services    |
	| 463 | Fingerprint officer                                           | Emergency and uniform services    |
	| 464 | Firefighter                                                   | Emergency and uniform services    |
	| 465 | Forensic collision investigator                               | Emergency and uniform services    |
	| 466 | Immigration officer                                           | Emergency and uniform services    |
	| 467 | Merchant Navy deck officer                                    | Emergency and uniform services    |
	| 468 | Merchant Navy engineering officer                             | Emergency and uniform services    |
	| 469 | Merchant Navy rating                                          | Emergency and uniform services    |
	| 470 | Neighbourhood warden                                          | Emergency and uniform services    |
	| 471 | Paramedic                                                     | Emergency and uniform services    |
	| 472 | Police community support officer                              | Emergency and uniform services    |
	| 473 | Police officer                                                | Emergency and uniform services    |
	| 474 | Prison governor                                               | Emergency and uniform services    |
	| 475 | Prison instructor                                             | Emergency and uniform services    |
	| 476 | Prison officer                                                | Emergency and uniform services    |
	| 477 | RAF airman or airwoman                                        | Emergency and uniform services    |
	| 478 | RAF non-commissioned aircrew                                  | Emergency and uniform services    |
	| 479 | RAF officer                                                   | Emergency and uniform services    |
	| 480 | Royal Marines commando                                        | Emergency and uniform services    |
	| 481 | Royal Marines officer                                         | Emergency and uniform services    |
	| 482 | Royal Navy officer                                            | Emergency and uniform services    |
	| 483 | Royal Navy rating                                             | Emergency and uniform services    |
	| 484 | Scenes of crime officer                                       | Emergency and uniform services    |
	| 485 | Security Service personnel                                    | Emergency and uniform services    |
	| 486 | Security manager                                              | Emergency and uniform services    |
	| 487 | Security officer                                              | Emergency and uniform services    |
	| 488 | Soldier                                                       | Emergency and uniform services    |
	| 489 | Store detective                                               | Emergency and uniform services    |
	| 490 | Aerospace engineer                                            | Engineering and maintenance       |
	| 491 | Aerospace engineering technician                              | Engineering and maintenance       |
	| 492 | Agricultural contractor                                       | Engineering and maintenance       |
	| 493 | Agricultural engineer                                         | Engineering and maintenance       |
	| 494 | Agricultural engineering technician                           | Engineering and maintenance       |
	| 495 | Air accident investigator                                     | Engineering and maintenance       |
	| 496 | Auto electrician                                              | Engineering and maintenance       |
	| 497 | Automotive engineer                                           | Engineering and maintenance       |
	| 498 | Bottler                                                       | Engineering and maintenance       |
	| 499 | CNC machinist                                                 | Engineering and maintenance       |
	| 500 | Caretaker                                                     | Engineering and maintenance       |
	| 501 | Cellar technician                                             | Engineering and maintenance       |
	| 502 | Chemical engineer                                             | Engineering and maintenance       |
	| 503 | Chemical engineering technician                               | Engineering and maintenance       |
	| 504 | Chimney sweep                                                 | Engineering and maintenance       |
	| 505 | Clinical engineer                                             | Engineering and maintenance       |
	| 506 | Critical care technologist                                    | Engineering and maintenance       |
	| 507 | Cycle mechanic                                                | Engineering and maintenance       |
	| 508 | Domestic appliance service engineer                           | Engineering and maintenance       |
	| 509 | Electrical engineer                                           | Engineering and maintenance       |
	| 510 | Electrical engineering technician                             | Engineering and maintenance       |
	| 511 | Electricity generation worker                                 | Engineering and maintenance       |
	| 512 | Electronics engineer                                          | Engineering and maintenance       |
	| 513 | Electronics engineering technician                            | Engineering and maintenance       |
	| 514 | Energy engineer                                               | Engineering and maintenance       |
	| 515 | Engineering craft machinist                                   | Engineering and maintenance       |
	| 516 | Engineering maintenance technician                            | Engineering and maintenance       |
	| 517 | Engineering operative                                         | Engineering and maintenance       |
	| 518 | Farrier                                                       | Engineering and maintenance       |
	| 519 | Fire safety engineer                                          | Engineering and maintenance       |
	| 520 | Food factory worker                                           | Engineering and maintenance       |
	| 521 | Forklift truck engineer                                       | Engineering and maintenance       |
	| 522 | Foundry mould maker                                           | Engineering and maintenance       |
	| 523 | Foundry process operator                                      | Engineering and maintenance       |
	| 524 | Garage manager                                                | Engineering and maintenance       |
	| 525 | Handyperson                                                   | Engineering and maintenance       |
	| 526 | Helicopter engineer                                           | Engineering and maintenance       |
	| 527 | Hydrologist                                                   | Engineering and maintenance       |
	| 528 | Lift engineer                                                 | Engineering and maintenance       |
	| 529 | Locksmith                                                     | Engineering and maintenance       |
	| 530 | Maintenance fitter                                            | Engineering and maintenance       |
	| 531 | Manufacturing systems engineer                                | Engineering and maintenance       |
	| 532 | Marine engineer                                               | Engineering and maintenance       |
	| 533 | Marine engineering technician                                 | Engineering and maintenance       |
	| 534 | Materials engineer                                            | Engineering and maintenance       |
	| 535 | Materials technician                                          | Engineering and maintenance       |
	| 536 | Mechanical engineer                                           | Engineering and maintenance       |
	| 537 | Metrologist                                                   | Engineering and maintenance       |
	| 538 | Motor mechanic                                                | Engineering and maintenance       |
	| 539 | Motor vehicle breakdown engineer                              | Engineering and maintenance       |
	| 540 | Motor vehicle fitter                                          | Engineering and maintenance       |
	| 541 | Motorcycle mechanic                                           | Engineering and maintenance       |
	| 542 | Motorsport engineer                                           | Engineering and maintenance       |
	| 543 | Non-destructive testing technician                            | Engineering and maintenance       |
	| 544 | Nuclear engineer                                              | Engineering and maintenance       |
	| 545 | Nuclear technician                                            | Engineering and maintenance       |
	| 546 | Offshore drilling worker                                      | Engineering and maintenance       |
	| 547 | Oil and gas operations manager                                | Engineering and maintenance       |
	| 548 | Patent attorney                                               | Engineering and maintenance       |
	| 549 | Physicist                                                     | Engineering and maintenance       |
	| 550 | Quality control assistant                                     | Engineering and maintenance       |
	| 551 | Rail track maintenance worker                                 | Engineering and maintenance       |
	| 552 | Railway signaller                                             | Engineering and maintenance       |
	| 553 | Recycling operative                                           | Engineering and maintenance       |
	| 554 | Robotics engineer                                             | Engineering and maintenance       |
	| 555 | Rolling stock engineering technician                          | Engineering and maintenance       |
	| 556 | Roustabout                                                    | Engineering and maintenance       |
	| 557 | Satellite engineer                                            | Engineering and maintenance       |
	| 558 | Security systems installer                                    | Engineering and maintenance       |
	| 559 | Shoe repairer                                                 | Engineering and maintenance       |
	| 560 | Signalling technician                                         | Engineering and maintenance       |
	| 561 | Smart meter installer                                         | Engineering and maintenance       |
	| 562 | Sterile services technician                                   | Engineering and maintenance       |
	| 563 | Surveying technician                                          | Engineering and maintenance       |
	| 564 | Technical brewer                                              | Engineering and maintenance       |
	| 565 | Telecoms engineer                                             | Engineering and maintenance       |
	| 566 | Toolmaker                                                     | Engineering and maintenance       |
	| 567 | Vehicle body repairer                                         | Engineering and maintenance       |
	| 568 | Vending machine operator                                      | Engineering and maintenance       |
	| 569 | Watch or clock repairer                                       | Engineering and maintenance       |
	| 570 | Water treatment worker                                        | Engineering and maintenance       |
	| 571 | Wind turbine technician                                       | Engineering and maintenance       |
	| 572 | Windscreen fitter                                             | Engineering and maintenance       |
	| 573 | Agricultural inspector                                        | Environment and land              |
	| 574 | Agronomist                                                    | Environment and land              |
	| 575 | Arboricultural officer                                        | Environment and land              |
	| 576 | Archaeologist                                                 | Environment and land              |
	| 577 | Bin worker                                                    | Environment and land              |
	| 578 | Biologist                                                     | Environment and land              |
	| 579 | Cartographer                                                  | Environment and land              |
	| 580 | Cemetery worker                                               | Environment and land              |
	| 581 | Climate scientist                                             | Environment and land              |
	| 582 | Corporate responsibility and sustainability practitioner      | Environment and land              |
	| 583 | Countryside officer                                           | Environment and land              |
	| 584 | Countryside ranger                                            | Environment and land              |
	| 585 | Ecologist                                                     | Environment and land              |
	| 586 | Environmental consultant                                      | Environment and land              |
	| 587 | Environmental health officer                                  | Environment and land              |
	| 588 | Farm worker                                                   | Environment and land              |
	| 589 | Farmer                                                        | Environment and land              |
	| 590 | Fish farmer                                                   | Environment and land              |
	| 591 | Food manufacturing inspector                                  | Environment and land              |
	| 592 | Forestry worker                                               | Environment and land              |
	| 593 | Gamekeeper                                                    | Environment and land              |
	| 594 | Gardener                                                      | Environment and land              |
	| 595 | Geoscientist                                                  | Environment and land              |
	| 596 | Geospatial technician                                         | Environment and land              |
	| 597 | Geotechnician                                                 | Environment and land              |
	| 598 | Groundsperson                                                 | Environment and land              |
	| 599 | Horticultural manager                                         | Environment and land              |
	| 600 | Horticultural therapist                                       | Environment and land              |
	| 601 | Horticultural worker                                          | Environment and land              |
	| 602 | Meat hygiene inspector                                        | Environment and land              |
	| 603 | Meteorologist                                                 | Environment and land              |
	| 604 | Oceanographer                                                 | Environment and land              |
	| 605 | Palaeontologist                                               | Environment and land              |
	| 606 | Pest control technician                                       | Environment and land              |
	| 607 | Recycled metals worker                                        | Environment and land              |
	| 608 | Recycling officer                                             | Environment and land              |
	| 609 | Research scientist                                            | Environment and land              |
	| 610 | Seismologist                                                  | Environment and land              |
	| 611 | Tractor driver                                                | Environment and land              |
	| 612 | Tree surgeon                                                  | Environment and land              |
	| 613 | Zoologist                                                     | Environment and land              |
	| 614 | Assistant immigration officer                                 | Government services               |
	| 615 | Careers adviser                                               | Government services               |
	| 616 | Child protection officer                                      | Government services               |
	| 617 | Civil Service administrative officer                          | Government services               |
	| 618 | Civil Service executive officer                               | Government services               |
	| 619 | Civil Service manager                                         | Government services               |
	| 620 | Criminologist                                                 | Government services               |
	| 621 | Data scientist                                                | Government services               |
	| 622 | Diplomatic Service officer                                    | Government services               |
	| 623 | Housing policy officer                                        | Government services               |
	| 624 | Intelligence analyst                                          | Government services               |
	| 625 | MP                                                            | Government services               |
	| 626 | Museum attendant                                              | Government services               |
	| 627 | Ofsted inspector                                              | Government services               |
	| 628 | Probation officer                                             | Government services               |
	| 629 | Probation services officer                                    | Government services               |
	| 630 | Registrar of births, deaths, marriages and civil partnerships | Government services               |
	| 631 | School crossing patrol                                        | Government services               |
	| 632 | Acupuncturist                                                 | Healthcare                        |
	| 633 | Ambulance care assistant                                      | Healthcare                        |
	| 634 | Anaesthetist                                                  | Healthcare                        |
	| 635 | Anatomical pathology technician                               | Healthcare                        |
	| 636 | Audiologist                                                   | Healthcare                        |
	| 637 | Biomedical scientist                                          | Healthcare                        |
	| 638 | Care home advocate                                            | Healthcare                        |
	| 639 | Care worker                                                   | Healthcare                        |
	| 640 | Children's nurse                                              | Healthcare                        |
	| 641 | Chiropractor                                                  | Healthcare                        |
	| 642 | Clinical psychologist                                         | Healthcare                        |
	| 643 | Clinical scientist                                            | Healthcare                        |
	| 644 | Cognitive behavioural therapist                               | Healthcare                        |
	| 645 | Community matron                                              | Healthcare                        |
	| 646 | Cosmetic surgeon                                              | Healthcare                        |
	| 647 | Counsellor                                                    | Healthcare                        |
	| 648 | Dance movement psychotherapist                                | Healthcare                        |
	| 649 | Dental hygienist                                              | Healthcare                        |
	| 650 | Dental nurse                                                  | Healthcare                        |
	| 651 | Dental technician                                             | Healthcare                        |
	| 652 | Dental therapist                                              | Healthcare                        |
	| 653 | Dentist                                                       | Healthcare                        |
	| 654 | Dietitian                                                     | Healthcare                        |
	| 655 | Dispensing optician                                           | Healthcare                        |
	| 656 | District nurse                                                | Healthcare                        |
	| 657 | Dramatherapist                                                | Healthcare                        |
	| 658 | Emergency care assistant                                      | Healthcare                        |
	| 659 | Emergency medical dispatcher                                  | Healthcare                        |
	| 660 | GP                                                            | Healthcare                        |
	| 661 | Geneticist                                                    | Healthcare                        |
	| 662 | Health play specialist                                        | Healthcare                        |
	| 663 | Health promotion specialist                                   | Healthcare                        |
	| 664 | Health service manager                                        | Healthcare                        |
	| 665 | Health trainer                                                | Healthcare                        |
	| 666 | Health visitor                                                | Healthcare                        |
	| 667 | Healthcare assistant                                          | Healthcare                        |
	| 668 | Healthcare science assistant                                  | Healthcare                        |
	| 669 | Homeopath                                                     | Healthcare                        |
	| 670 | Hospital doctor                                               | Healthcare                        |
	| 671 | Hospital porter                                               | Healthcare                        |
	| 672 | Hypnotherapist                                                | Healthcare                        |
	| 673 | Learning disability nurse                                     | Healthcare                        |
	| 674 | Maternity support worker                                      | Healthcare                        |
	| 675 | Medical herbalist                                             | Healthcare                        |
	| 676 | Medical physicist                                             | Healthcare                        |
	| 677 | Mental health nurse                                           | Healthcare                        |
	| 678 | Microbiologist                                                | Healthcare                        |
	| 679 | Midwife                                                       | Healthcare                        |
	| 680 | Naturopath                                                    | Healthcare                        |
	| 681 | Nurse                                                         | Healthcare                        |
	| 682 | Nursing associate                                             | Healthcare                        |
	| 683 | Nutritional therapist                                         | Healthcare                        |
	| 684 | Nutritionist                                                  | Healthcare                        |
	| 685 | Occupational health nurse                                     | Healthcare                        |
	| 686 | Occupational therapist                                        | Healthcare                        |
	| 687 | Occupational therapy support worker                           | Healthcare                        |
	| 688 | Operating department practitioner                             | Healthcare                        |
	| 689 | Optometrist                                                   | Healthcare                        |
	| 690 | Orthoptist                                                    | Healthcare                        |
	| 691 | Osteopath                                                     | Healthcare                        |
	| 692 | Paediatrician                                                 | Healthcare                        |
	| 693 | Palliative care assistant                                     | Healthcare                        |
	| 694 | Pathologist                                                   | Healthcare                        |
	| 695 | Patient advice and liaison service officer                    | Healthcare                        |
	| 696 | Patient transport service controller                          | Healthcare                        |
	| 697 | Pharmacist                                                    | Healthcare                        |
	| 698 | Pharmacologist                                                | Healthcare                        |
	| 699 | Pharmacy assistant                                            | Healthcare                        |
	| 700 | Pharmacy technician                                           | Healthcare                        |
	| 701 | Phlebotomist                                                  | Healthcare                        |
	| 702 | Physician associate                                           | Healthcare                        |
	| 703 | Physiotherapist                                               | Healthcare                        |
	| 704 | Physiotherapy assistant                                       | Healthcare                        |
	| 705 | Pilates teacher                                               | Healthcare                        |
	| 706 | Podiatrist                                                    | Healthcare                        |
	| 707 | Podiatry assistant                                            | Healthcare                        |
	| 708 | Practice nurse                                                | Healthcare                        |
	| 709 | Prosthetist-orthotist                                         | Healthcare                        |
	| 710 | Psychiatrist                                                  | Healthcare                        |
	| 711 | Psychological wellbeing practitioner                          | Healthcare                        |
	| 712 | Psychologist                                                  | Healthcare                        |
	| 713 | Psychotherapist                                               | Healthcare                        |
	| 714 | Radiographer                                                  | Healthcare                        |
	| 715 | Radiography assistant                                         | Healthcare                        |
	| 716 | Reiki healer                                                  | Healthcare                        |
	| 717 | School nurse                                                  | Healthcare                        |
	| 718 | Sonographer                                                   | Healthcare                        |
	| 719 | Speech and language therapist                                 | Healthcare                        |
	| 720 | Speech and language therapy assistant                         | Healthcare                        |
	| 721 | Sports development officer                                    | Healthcare                        |
	| 722 | Sports physiotherapist                                        | Healthcare                        |
	| 723 | Surgeon                                                       | Healthcare                        |
	| 724 | Yoga therapist                                                | Healthcare                        |
	| 725 | Accommodation warden                                          | Home services                     |
	| 726 | British Sign Language interpreter                             | Home services                     |
	| 727 | Butler                                                        | Home services                     |
	| 728 | Care escort                                                   | Home services                     |
	| 729 | Celebrant                                                     | Home services                     |
	| 730 | Chauffeur                                                     | Home services                     |
	| 731 | Cleaner                                                       | Home services                     |
	| 732 | Community transport driver                                    | Home services                     |
	| 733 | Crematorium technician                                        | Home services                     |
	| 734 | Dry cleaner                                                   | Home services                     |
	| 735 | Embalmer                                                      | Home services                     |
	| 736 | Highways cleaner                                              | Home services                     |
	| 737 | Industrial cleaner                                            | Home services                     |
	| 738 | Laundry worker                                                | Home services                     |
	| 739 | Life coach                                                    | Home services                     |
	| 740 | Personal shopper                                              | Home services                     |
	| 741 | Religious leader                                              | Home services                     |
	| 742 | Wedding planner                                               | Home services                     |
	| 743 | Window cleaner                                                | Home services                     |
	| 744 | Baker                                                         | Hospitality and food              |
	| 745 | Bar person                                                    | Hospitality and food              |
	| 746 | Barista                                                       | Hospitality and food              |
	| 747 | Butcher                                                       | Hospitality and food              |
	| 748 | Cake decorator                                                | Hospitality and food              |
	| 749 | Catering manager                                              | Hospitality and food              |
	| 750 | Chef                                                          | Hospitality and food              |
	| 751 | Consumer scientist                                            | Hospitality and food              |
	| 752 | Counter service assistant                                     | Hospitality and food              |
	| 753 | Cruise ship steward                                           | Hospitality and food              |
	| 754 | Fishmonger                                                    | Hospitality and food              |
	| 755 | Food scientist                                                | Hospitality and food              |
	| 756 | Head chef                                                     | Hospitality and food              |
	| 757 | Hotel manager                                                 | Hospitality and food              |
	| 758 | Hotel porter                                                  | Hospitality and food              |
	| 759 | Hotel room attendant                                          | Hospitality and food              |
	| 760 | Housekeeper                                                   | Hospitality and food              |
	| 761 | Kitchen porter                                                | Hospitality and food              |
	| 762 | Meat process worker                                           | Hospitality and food              |
	| 763 | Microbrewer                                                   | Hospitality and food              |
	| 764 | Publican                                                      | Hospitality and food              |
	| 765 | Restaurant manager                                            | Hospitality and food              |
	| 766 | School lunchtime supervisor                                   | Hospitality and food              |
	| 767 | Street food trader                                            | Hospitality and food              |
	| 768 | Waiter                                                        | Hospitality and food              |
	| 769 | Bailiff                                                       | Law and legal                     |
	| 770 | Barrister                                                     | Law and legal                     |
	| 771 | Barristers' clerk                                             | Law and legal                     |
	| 772 | Company secretary                                             | Law and legal                     |
	| 773 | Coroner                                                       | Law and legal                     |
	| 774 | Court administrative assistant                                | Law and legal                     |
	| 775 | Court legal adviser                                           | Law and legal                     |
	| 776 | Court usher                                                   | Law and legal                     |
	| 777 | Credit controller                                             | Law and legal                     |
	| 778 | Crown prosecutor                                              | Law and legal                     |
	| 779 | Equalities officer                                            | Law and legal                     |
	| 780 | Family mediator                                               | Law and legal                     |
	| 781 | Forensic psychologist                                         | Law and legal                     |
	| 782 | Forensic scientist                                            | Law and legal                     |
	| 783 | Immigration adviser (non-government)                          | Law and legal                     |
	| 784 | Interpreter                                                   | Law and legal                     |
	| 785 | Judge                                                         | Law and legal                     |
	| 786 | Legal executive                                               | Law and legal                     |
	| 787 | Legal secretary                                               | Law and legal                     |
	| 788 | Licensed conveyancer                                          | Law and legal                     |
	| 789 | Magistrate                                                    | Law and legal                     |
	| 790 | Paralegal                                                     | Law and legal                     |
	| 791 | Proofreader                                                   | Law and legal                     |
	| 792 | Solicitor                                                     | Law and legal                     |
	| 793 | Tax inspector                                                 | Law and legal                     |
	| 794 | Trade mark attorney                                           | Law and legal                     |
	| 795 | Trading standards officer                                     | Law and legal                     |
	| 796 | Victim care officer                                           | Law and legal                     |
	| 797 | Welfare rights officer                                        | Law and legal                     |
	| 798 | Bank manager                                                  | Managerial                        |
	| 799 | Bid writer                                                    | Managerial                        |
	| 800 | Business adviser                                              | Managerial                        |
	| 801 | Business analyst                                              | Managerial                        |
	| 802 | Business development manager                                  | Managerial                        |
	| 803 | Business project manager                                      | Managerial                        |
	| 804 | Care home manager                                             | Managerial                        |
	| 805 | Charity director                                              | Managerial                        |
	| 806 | Charity fundraiser                                            | Managerial                        |
	| 807 | Chief executive                                               | Managerial                        |
	| 808 | Community education co-ordinator                              | Managerial                        |
	| 809 | Credit manager                                                | Managerial                        |
	| 810 | Customer services manager                                     | Managerial                        |
	| 811 | Digital delivery manager                                      | Managerial                        |
	| 812 | E-commerce manager                                            | Managerial                        |
	| 813 | Economic development officer                                  | Managerial                        |
	| 814 | Economist                                                     | Managerial                        |
	| 815 | Estates officer                                               | Managerial                        |
	| 816 | Events manager                                                | Managerial                        |
	| 817 | GP practice manager                                           | Managerial                        |
	| 818 | Headteacher                                                   | Managerial                        |
	| 819 | Health and safety adviser                                     | Managerial                        |
	| 820 | Housing officer                                               | Managerial                        |
	| 821 | Human resources officer                                       | Managerial                        |
	| 822 | Leisure centre manager                                        | Managerial                        |
	| 823 | Management accountant                                         | Managerial                        |
	| 824 | Management consultant                                         | Managerial                        |
	| 825 | Network manager                                               | Managerial                        |
	| 826 | Nursery manager                                               | Managerial                        |
	| 827 | Office manager                                                | Managerial                        |
	| 828 | Operational researcher                                        | Managerial                        |
	| 829 | Payroll manager                                               | Managerial                        |
	| 830 | Private practice accountant                                   | Managerial                        |
	| 831 | Production manager (manufacturing)                            | Managerial                        |
	| 832 | Purchasing manager                                            | Managerial                        |
	| 833 | Quality assurance manager                                     | Managerial                        |
	| 834 | Retail manager                                                | Managerial                        |
	| 835 | Social services manager                                       | Managerial                        |
	| 836 | Supervisor                                                    | Managerial                        |
	| 837 | Technical architect                                           | Managerial                        |
	| 838 | Tour manager                                                  | Managerial                        |
	| 839 | Training manager                                              | Managerial                        |
	| 840 | Transport planner                                             | Managerial                        |
	| 841 | Travel agency manager                                         | Managerial                        |
	| 842 | Visitor attraction general manager                            | Managerial                        |
	| 843 | 3D printing technician                                        | Manufacturing                     |
	| 844 | Car manufacturing worker                                      | Manufacturing                     |
	| 845 | Chemical plant process operator                               | Manufacturing                     |
	| 846 | Footwear manufacturing operative                              | Manufacturing                     |
	| 847 | Garment technologist                                          | Manufacturing                     |
	| 848 | Leather technologist                                          | Manufacturing                     |
	| 849 | Packaging technologist                                        | Manufacturing                     |
	| 850 | Paper maker                                                   | Manufacturing                     |
	| 851 | Production worker (manufacturing)                             | Manufacturing                     |
	| 852 | Signmaker                                                     | Manufacturing                     |
	| 853 | Textile dyeing technician                                     | Manufacturing                     |
	| 854 | Textile operative                                             | Manufacturing                     |
	| 855 | Window fabricator                                             | Manufacturing                     |
	| 856 | Airline customer service agent                                | Retail and sales                  |
	| 857 | Airport information assistant                                 | Retail and sales                  |
	| 858 | Banking customer service adviser                              | Retail and sales                  |
	| 859 | Beauty consultant                                             | Retail and sales                  |
	| 860 | Bookmaker                                                     | Retail and sales                  |
	| 861 | Cabin crew                                                    | Retail and sales                  |
	| 862 | Call centre operator                                          | Retail and sales                  |
	| 863 | Car rental agent                                              | Retail and sales                  |
	| 864 | Cinema or theatre attendant                                   | Retail and sales                  |
	| 865 | Customer service assistant                                    | Retail and sales                  |
	| 866 | Estate agent                                                  | Retail and sales                  |
	| 867 | Insurance account manager                                     | Retail and sales                  |
	| 868 | Leisure centre assistant                                      | Retail and sales                  |
	| 869 | Letting agent                                                 | Retail and sales                  |
	| 870 | Market research executive                                     | Retail and sales                  |
	| 871 | Market trader                                                 | Retail and sales                  |
	| 872 | Medical sales representative                                  | Retail and sales                  |
	| 873 | Pet shop assistant                                            | Retail and sales                  |
	| 874 | Post Office customer service assistant                        | Retail and sales                  |
	| 875 | Retail buyer                                                  | Retail and sales                  |
	| 876 | Sales administrator                                           | Retail and sales                  |
	| 877 | Sales assistant                                               | Retail and sales                  |
	| 878 | Sales representative                                          | Retail and sales                  |
	| 879 | Shopkeeper                                                    | Retail and sales                  |
	| 880 | Telephonist                                                   | Retail and sales                  |
	| 881 | Tourist information centre assistant                          | Retail and sales                  |
	| 882 | Train station worker                                          | Retail and sales                  |
	| 883 | Travel agent                                                  | Retail and sales                  |
	| 884 | Wine merchant                                                 | Retail and sales                  |
	| 885 | Animal technician                                             | Science and research              |
	| 886 | Astronaut                                                     | Science and research              |
	| 887 | Astronomer                                                    | Science and research              |
	| 888 | Biochemist                                                    | Science and research              |
	| 889 | Biotechnologist                                               | Science and research              |
	| 890 | Chemist                                                       | Science and research              |
	| 891 | Data analyst-statistician                                     | Science and research              |
	| 892 | Education technician                                          | Science and research              |
	| 893 | Laboratory technician                                         | Science and research              |
	| 894 | Nanotechnologist                                              | Science and research              |
	| 895 | Performance sports scientist                                  | Science and research              |
	| 896 | Pet behaviour consultant                                      | Science and research              |
	| 897 | Sport and exercise psychologist                               | Science and research              |
	| 898 | Vet                                                           | Science and research              |
	| 899 | Childminder                                                   | Social care                       |
	| 900 | Communication support worker                                  | Social care                       |
	| 901 | Community development worker                                  | Social care                       |
	| 902 | Education welfare officer                                     | Social care                       |
	| 903 | Family support worker                                         | Social care                       |
	| 904 | Foster carer                                                  | Social care                       |
	| 905 | Funeral director                                              | Social care                       |
	| 906 | Learning mentor                                               | Social care                       |
	| 907 | Money adviser                                                 | Social care                       |
	| 908 | Nanny                                                         | Social care                       |
	| 909 | Nursery worker                                                | Social care                       |
	| 910 | Play therapist                                                | Social care                       |
	| 911 | Playworker                                                    | Social care                       |
	| 912 | Residential support worker                                    | Social care                       |
	| 913 | School houseparent                                            | Social care                       |
	| 914 | Senior care worker                                            | Social care                       |
	| 915 | Social work assistant                                         | Social care                       |
	| 916 | Social worker                                                 | Social care                       |
	| 917 | Substance misuse outreach worker                              | Social care                       |
	| 918 | Youth offending team officer                                  | Social care                       |
	| 919 | Youth worker                                                  | Social care                       |
	| 920 | Athlete                                                       | Sports and leisure                |
	| 921 | Cycling coach                                                 | Sports and leisure                |
	| 922 | Fitness instructor                                            | Sports and leisure                |
	| 923 | Football coach                                                | Sports and leisure                |
	| 924 | Football referee                                              | Sports and leisure                |
	| 925 | Horse riding instructor                                       | Sports and leisure                |
	| 926 | Jockey                                                        | Sports and leisure                |
	| 927 | Lifeguard                                                     | Sports and leisure                |
	| 928 | Martial arts instructor                                       | Sports and leisure                |
	| 929 | Outdoor activities instructor                                 | Sports and leisure                |
	| 930 | PE teacher                                                    | Sports and leisure                |
	| 931 | Personal trainer                                              | Sports and leisure                |
	| 932 | Racehorse trainer                                             | Sports and leisure                |
	| 933 | Resort representative                                         | Sports and leisure                |
	| 934 | Sailing instructor                                            | Sports and leisure                |
	| 935 | Sports coach                                                  | Sports and leisure                |
	| 936 | Sports professional                                           | Sports and leisure                |
	| 937 | Swimming teacher                                              | Sports and leisure                |
	| 938 | Yoga teacher                                                  | Sports and leisure                |
	| 939 | British Sign Language teacher                                 | Teaching and education            |
	| 940 | E-learning developer                                          | Teaching and education            |
	| 941 | Early years teacher                                           | Teaching and education            |
	| 942 | English as a foreign language (EFL) teacher                   | Teaching and education            |
	| 943 | Further education lecturer                                    | Teaching and education            |
	| 944 | Higher education lecturer                                     | Teaching and education            |
	| 945 | Librarian                                                     | Teaching and education            |
	| 946 | Library assistant                                             | Teaching and education            |
	| 947 | Montessori teacher                                            | Teaching and education            |
	| 948 | Online tutor                                                  | Teaching and education            |
	| 949 | Portage home visitor                                          | Teaching and education            |
	| 950 | Primary school teacher                                        | Teaching and education            |
	| 951 | QCF assessor                                                  | Teaching and education            |
	| 952 | School business manager                                       | Teaching and education            |
	| 953 | Secondary school teacher                                      | Teaching and education            |
	| 954 | Skills for life teacher                                       | Teaching and education            |
	| 955 | Special educational needs (SEN) teacher                       | Teaching and education            |
	| 956 | Special educational needs (SEN) teaching assistant            | Teaching and education            |
	| 957 | Teaching assistant                                            | Teaching and education            |
	| 958 | Trade union official                                          | Teaching and education            |
	| 959 | Training officer                                              | Teaching and education            |
	| 960 | Air traffic controller                                        | Transport                         |
	| 961 | Airline pilot                                                 | Transport                         |
	| 962 | Bus or coach driver                                           | Transport                         |
	| 963 | Car valet                                                     | Transport                         |
	| 964 | Driving instructor                                            | Transport                         |
	| 965 | Fishing vessel skipper                                        | Transport                         |
	| 966 | Helicopter pilot                                              | Transport                         |
	| 967 | Taxi driver                                                   | Transport                         |
	| 968 | Train conductor                                               | Transport                         |
	| 969 | Train driver                                                  | Transport                         |
	| 970 | Tram driver                                                   | Transport                         |
	| 971 | Tourist guide                                                 | Travel and tourism                |