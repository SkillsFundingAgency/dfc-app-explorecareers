Feature: ExploreCareersCUIcounts
		I want to reconcile counts between the production environment and the test environment

Scenario Outline: Compare Job profile search result counts in different environments
	Given I am at the "Search results" page
	And I search for the term <Job profile> of the <Job category> Job category
	And I note the number of search results
	And I surf to the "Production" environments "search results" page
	And I search for the term <Job profile> of the <Job category> Job category
	And I note the number of search results
	When I compare the number of search results noted from both environments
	Then the number is the same
Examples:
	| no.  | Job profile                                                   | Job category                      |
	| 1    | Admin assistant                                               | Administrator                     |
	| 2    | Arts administrator                                            | Administrator                     |
	| 3    | Assistant immigration officer                                 | Administrator                     |
	| 4    | Auditor                                                       | Administrator                     |
	| 5    | Bid writer                                                    | Administrator                     |
	| 6    | Bilingual secretary                                           | Administrator                     |
	| 7    | Bookkeeper                                                    | Administrator                     |
	| 8    | Border Force officer                                          | Administrator                     |
	| 9    | Car rental agent                                              | Administrator                     |
	| 10   | Charity fundraiser                                            | Administrator                     |
	| 11   | Civil Service administrative officer                          | Administrator                     |
	| 12   | Civil Service executive officer                               | Administrator                     |
	| 13   | Credit controller                                             | Administrator                     |
	| 14   | Data entry clerk                                              | Administrator                     |
	| 15   | Diplomatic Service officer                                    | Administrator                     |
	| 16   | Estates officer                                               | Administrator                     |
	| 17   | Farm secretary                                                | Administrator                     |
	| 18   | Finance officer                                               | Administrator                     |
	| 19   | Financial services customer adviser                           | Administrator                     |
	| 20   | GP practice manager                                           | Administrator                     |
	| 21   | Health and safety adviser                                     | Administrator                     |
	| 22   | Health records clerk                                          | Administrator                     |
	| 23   | Health service manager                                        | Administrator                     |
	| 24   | Human resources officer                                       | Administrator                     |
	| 25   | Immigration officer                                           | Administrator                     |
	| 26   | Import-export clerk                                           | Administrator                     |
	| 27   | Insurance broker                                              | Administrator                     |
	| 28   | Insurance technician                                          | Administrator                     |
	| 29   | Interpreter                                                   | Administrator                     |
	| 30   | Local government administrative assistant                     | Administrator                     |
	| 31   | Local government officer                                      | Administrator                     |
	| 32   | Local government revenues officer                             | Administrator                     |
	| 33   | Medical secretary                                             | Administrator                     |
	| 34   | Office manager                                                | Administrator                     |
	| 35   | Payroll administrator                                         | Administrator                     |
	| 36   | Personal assistant                                            | Administrator                     |
	| 37   | Post Office customer service assistant                        | Administrator                     |
	| 38   | Proofreader                                                   | Administrator                     |
	| 39   | Purchasing manager                                            | Administrator                     |
	| 40   | Quality control assistant                                     | Administrator                     |
	| 41   | Receptionist                                                  | Administrator                     |
	| 42   | Recruitment consultant                                        | Administrator                     |
	| 43   | Registrar of births, deaths, marriages and civil partnerships | Administrator                     |
	| 44   | Reprographic assistant                                        | Administrator                     |
	| 45   | Sales administrator                                           | Administrator                     |
	| 46   | School business manager                                       | Administrator                     |
	| 47   | School secretary                                              | Administrator                     |
	| 48   | Secretary                                                     | Administrator                     |
	| 49   | Security Service personnel                                    | Administrator                     |
	| 50   | Sports development officer                                    | Administrator                     |
	| 51   | Supervisor                                                    | Administrator                     |
	| 52   | Telephonist                                                   | Administrator                     |
	| 53   | Town planning assistant                                       | Administrator                     |
	| 54   | Trade union official                                          | Administrator                     |
	| 55   | Trading standards officer                                     | Administrator                     |
	| 56   | Agricultural contractor                                       | Animal care                       |
	| 57   | Agricultural inspector                                        | Animal care                       |
	| 58   | worker                                                        | Animal care                       |
	| 59   | Animal technician                                             | Animal care                       |
	| 60   | Dog training and behaviour adviser                            | Animal care                       |
	| 61   | Beekeeper                                                     | Animal care                       |
	| 62   | Biologist                                                     | Animal care                       |
	| 63   | Countryside ranger                                            | Animal care                       |
	| 64   | Dog groomer                                                   | Animal care                       |
	| 65   | Dog handler                                                   | Animal care                       |
	| 66   | Ecologist                                                     | Animal care                       |
	| 67   | Farm worker                                                   | Animal care                       |
	| 68   | Farmer                                                        | Animal care                       |
	| 69   | Farrier                                                       | Animal care                       |
	| 70   | Fish farmer                                                   | Animal care                       |
	| 71   | Fishing boat deckhand                                         | Animal care                       |
	| 72   | Gamekeeper                                                    | Animal care                       |
	| 73   | Horse groom                                                   | Animal care                       |
	| 74   | Horse riding instructor                                       | Animal care                       |
	| 75   | Jockey                                                        | Animal care                       |
	| 76   | Kennel worker                                                 | Animal care                       |
	| 77   | Pet behaviour consultant                                      | Animal care                       |
	| 78   | Pet shop assistant                                            | Animal care                       |
	| 79   | RSPCA inspector                                               | Animal care                       |
	| 80   | Racehorse trainer                                             | Animal care                       |
	| 81   | Vet                                                           | Animal care                       |
	| 82   | Veterinary nurse                                              | Animal care                       |
	| 83   | Veterinary physiotherapist                                    | Animal care                       |
	| 84   | Zookeeper                                                     | Animal care                       |
	| 85   | Zoologist                                                     | Animal care                       |
	| 86   | Local government administrative assistant                     | Animal care                       |
	| 87   | Local government officer                                      | Animal care                       |
	| 88   | Local government revenues officer                             | Animal care                       |
	| 89   | Medical secretary                                             | Animal care                       |
	| 90   | Office manager                                                | Animal care                       |
	| 91   | Payroll administrator                                         | Animal care                       |
	| 92   | Personal assistant                                            | Animal care                       |
	| 93   | Post Office customer service assistant                        | Animal care                       |
	| 94   | Proofreader                                                   | Animal care                       |
	| 95   | Purchasing manager                                            | Animal care                       |
	| 96   | Quality control assistant                                     | Animal care                       |
	| 97   | Receptionist                                                  | Animal care                       |
	| 98   | Recruitment consultant                                        | Animal care                       |
	| 99   | Registrar of births, deaths, marriages and civil partnerships | Animal care                       |
	| 100  | Reprographic assistant                                        | Animal care                       |
	| 101  | Sales administrator                                           | Animal care                       |
	| 102  | School business manager                                       | Animal care                       |
	| 103  | School secretary                                              | Animal care                       |
	| 104  | Secretary                                                     | Animal care                       |
	| 105  | Security Service personnel                                    | Animal care                       |
	| 106  | Sports development officer                                    | Animal care                       |
	| 107  | Supervisor                                                    | Animal care                       |
	| 108  | Telephonist                                                   | Animal care                       |
	| 109  | Town planning assistant                                       | Animal care                       |
	| 110  | Trade union official                                          | Animal care                       |
	| 111  | Trading standards officer                                     | Animal care                       |
	| 112  | Acupuncturist                                                 | Beauty and wellbeing              |
	| 113  | Aromatherapist                                                | Beauty and wellbeing              |
	| 114  | Art therapist                                                 | Beauty and wellbeing              |
	| 115  | Barber                                                        | Beauty and wellbeing              |
	| 116  | Beauty consultant                                             | Beauty and wellbeing              |
	| 117  | Beauty therapist                                              | Beauty and wellbeing              |
	| 118  | Chiropractor                                                  | Beauty and wellbeing              |
	| 119  | Counsellor                                                    | Beauty and wellbeing              |
	| 120  | Dance movement psychotherapist                                | Beauty and wellbeing              |
	| 121  | Dramatherapist                                                | Beauty and wellbeing              |
	| 122  | Hairdresser                                                   | Beauty and wellbeing              |
	| 123  | Health play specialist                                        | Beauty and wellbeing              |
	| 124  | Homeopath                                                     | Beauty and wellbeing              |
	| 125  | Massage therapist                                             | Beauty and wellbeing              |
	| 126  | Medical herbalist                                             | Beauty and wellbeing              |
	| 127  | Music therapist                                               | Beauty and wellbeing              |
	| 128  | Nail technician                                               | Beauty and wellbeing              |
	| 129  | Naturopath                                                    | Beauty and wellbeing              |
	| 130  | Nutritional therapist                                         | Beauty and wellbeing              |
	| 131  | Osteopath                                                     | Beauty and wellbeing              |
	| 132  | Pilates teacher                                               | Beauty and wellbeing              |
	| 133  | Reflexologist                                                 | Beauty and wellbeing              |
	| 134  | Reiki healer                                                  | Beauty and wellbeing              |
	| 135  | Tattooist and body piercer                                    | Beauty and wellbeing              |
	| 136  | Yoga therapist                                                | Beauty and wellbeing              |
	| 137  | Accounting technician                                         | Business and finance              |
	| 138  | Actuary                                                       | Business and finance              |
	| 139  | Auditor                                                       | Business and finance              |
	| 140  | Bank manager                                                  | Business and finance              |
	| 141  | Banking customer service adviser                              | Business and finance              |
	| 142  | Bookkeeper                                                    | Business and finance              |
	| 143  | Business adviser                                              | Business and finance              |
	| 144  | Business development manager                                  | Business and finance              |
	| 145  | Business project manager                                      | Business and finance              |
	| 146  | Chief executive                                               | Business and finance              |
	| 147  | Company secretary                                             | Business and finance              |
	| 148  | Corporate responsibility and sustainability practitioner      | Business and finance              |
	| 149  | Credit controller                                             | Business and finance              |
	| 150  | Credit manager                                                | Business and finance              |
	| 151  | Economist                                                     | Business and finance              |
	| 152  | Finance officer                                               | Business and finance              |
	| 153  | Financial adviser                                             | Business and finance              |
	| 154  | Financial services customer adviser                           | Business and finance              |
	| 155  | Insurance account manager                                     | Business and finance              |
	| 156  | Insurance broker                                              | Business and finance              |
	| 157  | Insurance claims handler                                      | Business and finance              |
	| 158  | Insurance loss adjuster                                       | Business and finance              |
	| 159  | Insurance risk surveyor                                       | Business and finance              |
	| 160  | Insurance technician                                          | Business and finance              |
	| 161  | Insurance underwriter                                         | Business and finance              |
	| 162  | Investment analyst                                            | Business and finance              |
	| 163  | Local government revenues officer                             | Business and finance              |
	| 164  | Management accountant                                         | Business and finance              |
	| 165  | Market research executive                                     | Business and finance              |
	| 166  | Marketing manager                                             | Business and finance              |
	| 167  | Money adviser                                                 | Business and finance              |
	| 168  | Mortgage adviser                                              | Business and finance              |
	| 169  | Payroll administrator                                         | Business and finance              |
	| 170  | Payroll manager                                               | Business and finance              |
	| 171  | Pensions administrator                                        | Business and finance              |
	| 172  | Pensions adviser                                              | Business and finance              |
	| 173  | Private practice accountant                                   | Business and finance              |
	| 174  | Public finance accountant                                     | Business and finance              |
	| 175  | School business manager                                       | Business and finance              |
	| 176  | Stockbroker                                                   | Business and finance              |
	| 177  | Tax adviser                                                   | Business and finance              |
	| 178  | Tax inspector                                                 | Business and finance              |
	| 179  | 3D printing technician                                        | Computing, technology and digital |
	| 180  | App developer                                                 | Computing, technology and digital |
	| 181  | Archivist                                                     | Computing, technology and digital |
	| 182  | Business analyst                                              | Computing, technology and digital |
	| 183  | Cartographer                                                  | Computing, technology and digital |
	| 184  | Computer games developer                                      | Computing, technology and digital |
	| 185  | Computer games tester                                         | Computing, technology and digital |
	| 186  | Cyber intelligence officer                                    | Computing, technology and digital |
	| 187  | Data entry clerk                                              | Computing, technology and digital |
	| 188  | Data scientist                                                | Computing, technology and digital |
	| 189  | Database administrator                                        | Computing, technology and digital |
	| 190  | Digital delivery manager                                      | Computing, technology and digital |
	| 191  | Digital product owner                                         | Computing, technology and digital |
	| 192  | E-learning developer                                          | Computing, technology and digital |
	| 193  | Forensic computer analyst                                     | Computing, technology and digital |
	| 194  | Geospatial technician                                         | Computing, technology and digital |
	| 195  | IT project manager                                            | Computing, technology and digital |
	| 196  | IT security co-ordinator                                      | Computing, technology and digital |
	| 197  | IT support technician                                         | Computing, technology and digital |
	| 198  | IT trainer                                                    | Computing, technology and digital |
	| 199  | Indexer                                                       | Computing, technology and digital |
	| 200  | Information scientist                                         | Computing, technology and digital |
	| 201  | Librarian                                                     | Computing, technology and digital |
	| 202  | Library assistant                                             | Computing, technology and digital |
	| 203  | Media researcher                                              | Computing, technology and digital |
	| 204  | Network engineer                                              | Computing, technology and digital |
	| 205  | Network manager                                               | Computing, technology and digital |
	| 206  | Operational researcher                                        | Computing, technology and digital |
	| 207  | Pre-press operator                                            | Computing, technology and digital |
	| 208  | Robotics engineer                                             | Computing, technology and digital |
	| 209  | Security Service personnel                                    | Computing, technology and digital |
	| 210  | Social media manager                                          | Computing, technology and digital |
	| 211  | Software developer                                            | Computing, technology and digital |
	| 212  | Solutions architect                                           | Computing, technology and digital |
	| 213  | Systems analyst                                               | Computing, technology and digital |
	| 214  | Technical architect                                           | Computing, technology and digital |
	| 215  | Technical author                                              | Computing, technology and digital |
	| 216  | Telephonist                                                   | Computing, technology and digital |
	| 217  | Test lead                                                     | Computing, technology and digital |
	| 218  | User experience (UX) designer                                 | Computing, technology and digital |
	| 219  | User researcher                                               | Computing, technology and digital |
	| 220  | Vlogger                                                       | Computing, technology and digital |
	| 221  | Web content editor                                            | Computing, technology and digital |
	| 222  | Web content manager                                           | Computing, technology and digital |
	| 223  | Web designer                                                  | Computing, technology and digital |
	| 224  | Web developer                                                 | Computing, technology and digital |
	| 225  | Acoustics consultant                                          | Construction and trades           |
	| 226  | Architect                                                     | Construction and trades           |
	| 227  | Architectural technician                                      | Construction and trades           |
	| 228  | Architectural technologist                                    | Construction and trades           |
	| 229  | Boat builder                                                  | Construction and trades           |
	| 230  | Bricklayer                                                    | Construction and trades           |
	| 231  | Builders' merchant                                            | Construction and trades           |
	| 232  | Building control officer                                      | Construction and trades           |
	| 233  | Building services engineer                                    | Construction and trades           |
	| 234  | Building site inspector                                       | Construction and trades           |
	| 235  | Building surveyor                                             | Construction and trades           |
	| 236  | Building technician                                           | Construction and trades           |
	| 237  | CAD technician                                                | Construction and trades           |
	| 238  | Carpenter                                                     | Construction and trades           |
	| 239  | Carpet fitter and floor layer                                 | Construction and trades           |
	| 240  | Cavity insulation installer                                   | Construction and trades           |
	| 241  | Ceiling fixer                                                 | Construction and trades           |
	| 242  | Civil engineer                                                | Construction and trades           |
	| 243  | Civil engineering technician                                  | Construction and trades           |
	| 244  | Commercial energy assessor                                    | Construction and trades           |
	| 245  | Construction contracts manager                                | Construction and trades           |
	| 246  | Construction labourer                                         | Construction and trades           |
	| 247  | Construction manager                                          | Construction and trades           |
	| 248  | Construction plant hire adviser                               | Construction and trades           |
	| 249  | Construction plant mechanic                                   | Construction and trades           |
	| 250  | Construction plant operator                                   | Construction and trades           |
	| 251  | Construction site supervisor                                  | Construction and trades           |
	| 252  | Crane driver                                                  | Construction and trades           |
	| 253  | Demolition operative                                          | Construction and trades           |
	| 254  | Domestic energy assessor                                      | Construction and trades           |
	| 255  | Dry liner                                                     | Construction and trades           |
	| 256  | Electrician                                                   | Construction and trades           |
	| 257  | Electricity distribution worker                               | Construction and trades           |
	| 258  | Engineering construction craftworker                          | Construction and trades           |
	| 259  | Engineering construction technician                           | Construction and trades           |
	| 260  | Estimator                                                     | Construction and trades           |
	| 261  | Facilities manager                                            | Construction and trades           |
	| 262  | Fence installer                                               | Construction and trades           |
	| 263  | Gas mains layer                                               | Construction and trades           |
	| 264  | Gas service technician                                        | Construction and trades           |
	| 265  | General practice surveyor                                     | Construction and trades           |
	| 266  | Glazier                                                       | Construction and trades           |
	| 267  | Heating and ventilation engineer                              | Construction and trades           |
	| 268  | Heritage officer                                              | Construction and trades           |
	| 269  | Kitchen and bathroom fitter                                   | Construction and trades           |
	| 270  | Land and property valuer and auctioneer                       | Construction and trades           |
	| 271  | Land surveyor                                                 | Construction and trades           |
	| 272  | Landscaper                                                    | Construction and trades           |
	| 273  | Mechanical engineering technician                             | Construction and trades           |
	| 274  | Paint sprayer                                                 | Construction and trades           |
	| 275  | Painter and decorator                                         | Construction and trades           |
	| 276  | Pipe fitter                                                   | Construction and trades           |
	| 277  | Planning and development surveyor                             | Construction and trades           |
	| 278  | Plasterer                                                     | Construction and trades           |
	| 279  | Plumber                                                       | Construction and trades           |
	| 280  | Quantity surveyor                                             | Construction and trades           |
	| 281  | Quarry engineer                                               | Construction and trades           |
	| 282  | Quarry worker                                                 | Construction and trades           |
	| 283  | Refrigeration and air-conditioning installer                  | Construction and trades           |
	| 284  | Road worker                                                   | Construction and trades           |
	| 285  | Roofer                                                        | Construction and trades           |
	| 286  | Rural surveyor                                                | Construction and trades           |
	| 287  | Scaffolder                                                    | Construction and trades           |
	| 288  | Shopfitter                                                    | Construction and trades           |
	| 289  | Steel erector                                                 | Construction and trades           |
	| 290  | Steel fixer                                                   | Construction and trades           |
	| 291  | Steeplejack                                                   | Construction and trades           |
	| 292  | Stonemason                                                    | Construction and trades           |
	| 293  | Structural engineer                                           | Construction and trades           |
	| 294  | Technical surveyor                                            | Construction and trades           |
	| 295  | Thatcher                                                      | Construction and trades           |
	| 296  | Thermal insulation engineer                                   | Construction and trades           |
	| 297  | Tiler                                                         | Construction and trades           |
	| 298  | Town planner                                                  | Construction and trades           |
	| 299  | Town planning assistant                                       | Construction and trades           |
	| 300  | Water network operative                                       | Construction and trades           |
	| 301  | Welder                                                        | Construction and trades           |
	| 302  | Window fitter                                                 | Construction and trades           |
	| 303  | Wood machinist                                                | Construction and trades           |
	| 304  | Actor                                                         | Creative and media                |
	| 305  | Advertising account executive                                 | Creative and media                |
	| 306  | Advertising account planner                                   | Creative and media                |
	| 307  | Advertising art director                                      | Creative and media                |
	| 308  | Advertising copywriter                                        | Creative and media                |
	| 309  | Advertising media buyer                                       | Creative and media                |
	| 310  | Advertising media planner                                     | Creative and media                |
	| 311  | Animator                                                      | Creative and media                |
	| 312  | Antique dealer                                                | Creative and media                |
	| 313  | Architect                                                     | Creative and media                |
	| 314  | Architectural technician                                      | Creative and media                |
	| 315  | Architectural technologist                                    | Creative and media                |
	| 316  | Archivist                                                     | Creative and media                |
	| 317  | Art editor                                                    | Creative and media                |
	| 318  | Art therapist                                                 | Creative and media                |
	| 319  | Art valuer                                                    | Creative and media                |
	| 320  | Arts administrator                                            | Creative and media                |
	| 321  | Audio-visual technician                                       | Creative and media                |
	| 322  | Blacksmith                                                    | Creative and media                |
	| 323  | Bookbinder                                                    | Creative and media                |
	| 324  | Bookseller                                                    | Creative and media                |
	| 325  | Broadcast engineer                                            | Creative and media                |
	| 326  | Broadcast journalist                                          | Creative and media                |
	| 327  | Ceramics designer-maker                                       | Creative and media                |
	| 328  | Choreographer                                                 | Creative and media                |
	| 329  | Commissioning editor                                          | Creative and media                |
	| 330  | Community arts worker                                         | Creative and media                |
	| 331  | Computer games tester                                         | Creative and media                |
	| 332  | Conservator                                                   | Creative and media                |
	| 333  | Copy editor                                                   | Creative and media                |
	| 334  | Costume designer                                              | Creative and media                |
	| 335  | DJ                                                            | Creative and media                |
	| 336  | Dance teacher                                                 | Creative and media                |
	| 337  | Dancer                                                        | Creative and media                |
	| 338  | Design and development engineer                               | Creative and media                |
	| 339  | Director of photography                                       | Creative and media                |
	| 340  | Dressmaker                                                    | Creative and media                |
	| 341  | Drone pilot                                                   | Creative and media                |
	| 342  | Editorial assistant                                           | Creative and media                |
	| 343  | Entertainer                                                   | Creative and media                |
	| 344  | Ergonomist                                                    | Creative and media                |
	| 345  | Exhibition designer                                           | Creative and media                |
	| 346  | Fashion design assistant                                      | Creative and media                |
	| 347  | Fashion designer                                              | Creative and media                |
	| 348  | Fashion model                                                 | Creative and media                |
	| 349  | Film critic                                                   | Creative and media                |
	| 350  | Fine artist                                                   | Creative and media                |
	| 351  | Florist                                                       | Creative and media                |
	| 352  | Footwear designer                                             | Creative and media                |
	| 353  | Franchise owner                                               | Creative and media                |
	| 354  | French polisher                                               | Creative and media                |
	| 355  | Furniture designer                                            | Creative and media                |
	| 356  | Furniture maker                                               | Creative and media                |
	| 357  | Furniture restorer                                            | Creative and media                |
	| 358  | Glassmaker                                                    | Creative and media                |
	| 359  | Graphic designer                                              | Creative and media                |
	| 360  | Illustrator                                                   | Creative and media                |
	| 361  | Indexer                                                       | Creative and media                |
	| 362  | Interior designer                                             | Creative and media                |
	| 363  | Jewellery designer-maker                                      | Creative and media                |
	| 364  | Kitchen and bathroom designer                                 | Creative and media                |
	| 365  | Knitting machinist                                            | Creative and media                |
	| 366  | Landscape architect                                           | Creative and media                |
	| 367  | Leather craftworker                                           | Creative and media                |
	| 368  | Lighting technician                                           | Creative and media                |
	| 369  | Live sound engineer                                           | Creative and media                |
	| 370  | Magazine journalist                                           | Creative and media                |
	| 371  | Make-up artist                                                | Creative and media                |
	| 372  | Market research data analyst                                  | Creative and media                |
	| 373  | Market researcher                                             | Creative and media                |
	| 374  | Marketing executive                                           | Creative and media                |
	| 375  | Marketing manager                                             | Creative and media                |
	| 376  | Media researcher                                              | Creative and media                |
	| 377  | Medical illustrator                                           | Creative and media                |
	| 378  | Model maker                                                   | Creative and media                |
	| 379  | Museum curator                                                | Creative and media                |
	| 380  | Music promotions manager                                      | Creative and media                |
	| 381  | Music teacher                                                 | Creative and media                |
	| 382  | Music therapist                                               | Creative and media                |
	| 383  | Musical instrument maker and repairer                         | Creative and media                |
	| 384  | Musician                                                      | Creative and media                |
	| 385  | Naval architect                                               | Creative and media                |
	| 386  | Newspaper journalist                                          | Creative and media                |
	| 387  | Newspaper or magazine editor                                  | Creative and media                |
	| 388  | Pattern cutter                                                | Creative and media                |
	| 389  | Photographer                                                  | Creative and media                |
	| 390  | Photographic stylist                                          | Creative and media                |
	| 391  | Photographic technician                                       | Creative and media                |
	| 392  | Picture framer                                                | Creative and media                |
	| 393  | Pre-press operator                                            | Creative and media                |
	| 394  | Product designer                                              | Creative and media                |
	| 395  | Prop maker                                                    | Creative and media                |
	| 396  | Public relations director                                     | Creative and media                |
	| 397  | Public relations officer                                      | Creative and media                |
	| 398  | Radio broadcast assistant                                     | Creative and media                |
	| 399  | Reprographic assistant                                        | Creative and media                |
	| 400  | Retail merchandiser                                           | Creative and media                |
	| 401  | Roadie                                                        | Creative and media                |
	| 402  | Sales manager                                                 | Creative and media                |
	| 403  | Screenwriter                                                  | Creative and media                |
	| 404  | Set designer                                                  | Creative and media                |
	| 405  | Sewing machinist                                              | Creative and media                |
	| 406  | Signwriter                                                    | Creative and media                |
	| 407  | Sports commentator                                            | Creative and media                |
	| 408  | Stage manager                                                 | Creative and media                |
	| 409  | Stagehand                                                     | Creative and media                |
	| 410  | Stonemason                                                    | Creative and media                |
	| 411  | Studio sound engineer                                         | Creative and media                |
	| 412  | Sub-editor                                                    | Creative and media                |
	| 413  | TV or film assistant director                                 | Creative and media                |
	| 414  | TV or film assistant production co-ordinator                  | Creative and media                |
	| 415  | TV or film camera operator                                    | Creative and media                |
	| 416  | TV or film director                                           | Creative and media                |
	| 417  | TV or film producer                                           | Creative and media                |
	| 418  | TV or film production manager                                 | Creative and media                |
	| 419  | TV or film production runner                                  | Creative and media                |
	| 420  | TV or film sound technician                                   | Creative and media                |
	| 421  | TV presenter                                                  | Creative and media                |
	| 422  | Tailor                                                        | Creative and media                |
	| 423  | Tattooist and body piercer                                    | Creative and media                |
	| 424  | Taxidermist                                                   | Creative and media                |
	| 425  | Technical author                                              | Creative and media                |
	| 426  | Technical textiles designer                                   | Creative and media                |
	| 427  | Textile designer                                              | Creative and media                |
	| 428  | Textiles production manager                                   | Creative and media                |
	| 429  | Translator                                                    | Creative and media                |
	| 430  | Upholsterer                                                   | Creative and media                |
	| 431  | Video editor                                                  | Creative and media                |
	| 432  | Visual merchandiser                                           | Creative and media                |
	| 433  | Vlogger                                                       | Creative and media                |
	| 434  | Wardrobe assistant                                            | Creative and media                |
	| 435  | Web content editor                                            | Creative and media                |
	| 436  | Web designer                                                  | Creative and media                |
	| 437  | Writer                                                        | Creative and media                |
	| 438  | Airport baggage handler                                       | Delivery and storage              |
	| 439  | Builders' merchant                                            | Delivery and storage              |
	| 440  | Delivery van driver                                           | Delivery and storage              |
	| 441  | Food packaging operative                                      | Delivery and storage              |
	| 442  | Forklift driver                                               | Delivery and storage              |
	| 443  | Import-export clerk                                           | Delivery and storage              |
	| 444  | Large goods vehicle driver                                    | Delivery and storage              |
	| 445  | Motor vehicle parts person                                    | Delivery and storage              |
	| 446  | Order picker                                                  | Delivery and storage              |
	| 447  | Packer                                                        | Delivery and storage              |
	| 448  | Port operative                                                | Delivery and storage              |
	| 449  | Postperson                                                    | Delivery and storage              |
	| 450  | Removals worker                                               | Delivery and storage              |
	| 451  | Road transport manager                                        | Delivery and storage              |
	| 452  | Roadie                                                        | Delivery and storage              |
	| 453  | Shelf filler                                                  | Delivery and storage              |
	| 454  | Stock control assistant                                       | Delivery and storage              |
	| 455  | Supply chain manager                                          | Delivery and storage              |
	| 456  | Tanker driver                                                 | Delivery and storage              |
	| 457  | Warehouse manager                                             | Delivery and storage              |
	| 458  | Warehouse worker                                              | Delivery and storage              |
	| 459  | Aid worker                                                    | Emergency and uniform services    |
	| 460  | Army officer                                                  | Emergency and uniform services    |
	| 461  | Bodyguard                                                     | Emergency and uniform services    |
	| 462  | Border Force officer                                          | Emergency and uniform services    |
	| 463  | Chief inspector                                               | Emergency and uniform services    |
	| 464  | Civil enforcement officer                                     | Emergency and uniform services    |
	| 465  | Coastguard                                                    | Emergency and uniform services    |
	| 466  | Diver                                                         | Emergency and uniform services    |
	| 467  | Dog handler                                                   | Emergency and uniform services    |
	| 468  | Door supervisor                                               | Emergency and uniform services    |
	| 469  | Fingerprint officer                                           | Emergency and uniform services    |
	| 470  | Firefighter                                                   | Emergency and uniform services    |
	| 471  | Forensic collision investigator                               | Emergency and uniform services    |
	| 472  | Immigration officer                                           | Emergency and uniform services    |
	| 473  | Merchant Navy deck officer                                    | Emergency and uniform services    |
	| 474  | Merchant Navy engineering officer                             | Emergency and uniform services    |
	| 475  | Merchant Navy rating                                          | Emergency and uniform services    |
	| 476  | Neighbourhood warden                                          | Emergency and uniform services    |
	| 477  | Paramedic                                                     | Emergency and uniform services    |
	| 478  | Police community support officer                              | Emergency and uniform services    |
	| 479  | Police officer                                                | Emergency and uniform services    |
	| 480  | Prison governor                                               | Emergency and uniform services    |
	| 481  | Prison instructor                                             | Emergency and uniform services    |
	| 482  | Prison officer                                                | Emergency and uniform services    |
	| 483  | RAF airman or airwoman                                        | Emergency and uniform services    |
	| 484  | RAF non-commissioned aircrew                                  | Emergency and uniform services    |
	| 485  | RAF officer                                                   | Emergency and uniform services    |
	| 486  | Royal Marines commando                                        | Emergency and uniform services    |
	| 487  | Royal Marines officer                                         | Emergency and uniform services    |
	| 488  | Royal Navy officer                                            | Emergency and uniform services    |
	| 489  | Royal Navy rating                                             | Emergency and uniform services    |
	| 490  | Scenes of crime officer                                       | Emergency and uniform services    |
	| 491  | Security Service personnel                                    | Emergency and uniform services    |
	| 492  | Security manager                                              | Emergency and uniform services    |
	| 493  | Security officer                                              | Emergency and uniform services    |
	| 494  | Soldier                                                       | Emergency and uniform services    |
	| 495  | Store detective                                               | Emergency and uniform services    |
	| 496  | Acoustics consultant                                          | Engineering and maintenance       |
	| 497  | Aerospace engineer                                            | Engineering and maintenance       |
	| 498  | Aerospace engineering technician                              | Engineering and maintenance       |
	| 499  | Agricultural contractor                                       | Engineering and maintenance       |
	| 500  | Agricultural engineer                                         | Engineering and maintenance       |
	| 501  | Agricultural engineering technician                           | Engineering and maintenance       |
	| 502  | Air accident investigator                                     | Engineering and maintenance       |
	| 503  | Audio-visual technician                                       | Engineering and maintenance       |
	| 504  | Auto electrician                                              | Engineering and maintenance       |
	| 505  | Automotive engineer                                           | Engineering and maintenance       |
	| 506  | Boat builder                                                  | Engineering and maintenance       |
	| 507  | Bottler                                                       | Engineering and maintenance       |
	| 508  | Broadcast engineer                                            | Engineering and maintenance       |
	| 509  | Building control officer                                      | Engineering and maintenance       |
	| 510  | Building services engineer                                    | Engineering and maintenance       |
	| 511  | Building site inspector                                       | Engineering and maintenance       |
	| 512  | CAD technician                                                | Engineering and maintenance       |
	| 513  | CNC machinist                                                 | Engineering and maintenance       |
	| 514  | Caretaker                                                     | Engineering and maintenance       |
	| 515  | Cellar technician                                             | Engineering and maintenance       |
	| 516  | Chemical engineer                                             | Engineering and maintenance       |
	| 517  | Chemical engineering technician                               | Engineering and maintenance       |
	| 518  | Chimney sweep                                                 | Engineering and maintenance       |
	| 519  | Civil engineer                                                | Engineering and maintenance       |
	| 520  | Civil engineering technician                                  | Engineering and maintenance       |
	| 521  | Clinical engineer                                             | Engineering and maintenance       |
	| 522  | Construction plant mechanic                                   | Engineering and maintenance       |
	| 523  | Critical care technologist                                    | Engineering and maintenance       |
	| 524  | Cycle mechanic                                                | Engineering and maintenance       |
	| 525  | Design and development engineer                               | Engineering and maintenance       |
	| 526  | Diver                                                         | Engineering and maintenance       |
	| 527  | Domestic appliance service engineer                           | Engineering and maintenance       |
	| 528  | Drone pilot                                                   | Engineering and maintenance       |
	| 529  | Electrical engineer                                           | Engineering and maintenance       |
	| 530  | Electrical engineering technician                             | Engineering and maintenance       |
	| 531  | Electrician                                                   | Engineering and maintenance       |
	| 532  | Electricity distribution worker                               | Engineering and maintenance       |
	| 533  | Electricity generation worker                                 | Engineering and maintenance       |
	| 534  | Electronics engineer                                          | Engineering and maintenance       |
	| 535  | Electronics engineering technician                            | Engineering and maintenance       |
	| 536  | Energy engineer                                               | Engineering and maintenance       |
	| 537  | Engineering construction craftworker                          | Engineering and maintenance       |
	| 538  | Engineering construction technician                           | Engineering and maintenance       |
	| 539  | Engineering craft machinist                                   | Engineering and maintenance       |
	| 540  | Engineering maintenance technician                            | Engineering and maintenance       |
	| 541  | Engineering operative                                         | Engineering and maintenance       |
	| 542  | Ergonomist                                                    | Engineering and maintenance       |
	| 543  | Farrier                                                       | Engineering and maintenance       |
	| 544  | Fire safety engineer                                          | Engineering and maintenance       |
	| 545  | Food factory worker                                           | Engineering and maintenance       |
	| 546  | Forklift truck engineer                                       | Engineering and maintenance       |
	| 547  | Foundry mould maker                                           | Engineering and maintenance       |
	| 548  | Foundry process operator                                      | Engineering and maintenance       |
	| 549  | Furniture maker                                               | Engineering and maintenance       |
	| 550  | Garage manager                                                | Engineering and maintenance       |
	| 551  | Gas mains layer                                               | Engineering and maintenance       |
	| 552  | Gas service technician                                        | Engineering and maintenance       |
	| 553  | Glazier                                                       | Engineering and maintenance       |
	| 554  | Handyperson                                                   | Engineering and maintenance       |
	| 555  | Heating and ventilation engineer                              | Engineering and maintenance       |
	| 556  | Helicopter engineer                                           | Engineering and maintenance       |
	| 557  | Hydrologist                                                   | Engineering and maintenance       |
	| 558  | Lift engineer                                                 | Engineering and maintenance       |
	| 559  | Lighting technician                                           | Engineering and maintenance       |
	| 560  | Live sound engineer                                           | Engineering and maintenance       |
	| 561  | Locksmith                                                     | Engineering and maintenance       |
	| 562  | Maintenance fitter                                            | Engineering and maintenance       |
	| 563  | Manufacturing systems engineer                                | Engineering and maintenance       |
	| 564  | Marine engineer                                               | Engineering and maintenance       |
	| 565  | Marine engineering technician                                 | Engineering and maintenance       |
	| 566  | Materials engineer                                            | Engineering and maintenance       |
	| 567  | Materials technician                                          | Engineering and maintenance       |
	| 568  | Mechanical engineer                                           | Engineering and maintenance       |
	| 569  | Mechanical engineering technician                             | Engineering and maintenance       |
	| 570  | Merchant Navy engineering officer                             | Engineering and maintenance       |
	| 571  | Metrologist                                                   | Engineering and maintenance       |
	| 572  | Model maker                                                   | Engineering and maintenance       |
	| 573  | Motor mechanic                                                | Engineering and maintenance       |
	| 574  | Motor vehicle breakdown engineer                              | Engineering and maintenance       |
	| 575  | Motor vehicle fitter                                          | Engineering and maintenance       |
	| 576  | Motorcycle mechanic                                           | Engineering and maintenance       |
	| 577  | Motorsport engineer                                           | Engineering and maintenance       |
	| 578  | Naval architect                                               | Engineering and maintenance       |
	| 579  | Non-destructive testing technician                            | Engineering and maintenance       |
	| 580  | Nuclear engineer                                              | Engineering and maintenance       |
	| 581  | Nuclear technician                                            | Engineering and maintenance       |
	| 582  | Offshore drilling worker                                      | Engineering and maintenance       |
	| 583  | Oil and gas operations manager                                | Engineering and maintenance       |
	| 584  | Patent attorney                                               | Engineering and maintenance       |
	| 585  | Physicist                                                     | Engineering and maintenance       |
	| 586  | Pipe fitter                                                   | Engineering and maintenance       |
	| 587  | Plumber                                                       | Engineering and maintenance       |
	| 588  | Product designer                                              | Engineering and maintenance       |
	| 589  | Quality control assistant                                     | Engineering and maintenance       |
	| 590  | Quantity surveyor                                             | Engineering and maintenance       |
	| 591  | Quarry engineer                                               | Engineering and maintenance       |
	| 592  | Quarry worker                                                 | Engineering and maintenance       |
	| 593  | Rail track maintenance worker                                 | Engineering and maintenance       |
	| 594  | Railway signaller                                             | Engineering and maintenance       |
	| 595  | Recycling operative                                           | Engineering and maintenance       |
	| 596  | Refrigeration and air-conditioning installer                  | Engineering and maintenance       |
	| 597  | Road worker                                                   | Engineering and maintenance       |
	| 598  | Robotics engineer                                             | Engineering and maintenance       |
	| 599  | Rolling stock engineering technician                          | Engineering and maintenance       |
	| 600  | Roustabout                                                    | Engineering and maintenance       |
	| 601  | Satellite engineer                                            | Engineering and maintenance       |
	| 602  | Security systems installer                                    | Engineering and maintenance       |
	| 603  | Shoe repairer                                                 | Engineering and maintenance       |
	| 604  | Signalling technician                                         | Engineering and maintenance       |
	| 605  | Smart meter installer                                         | Engineering and maintenance       |
	| 606  | Steel erector                                                 | Engineering and maintenance       |
	| 607  | Steel fixer                                                   | Engineering and maintenance       |
	| 608  | Sterile services technician                                   | Engineering and maintenance       |
	| 609  | Structural engineer                                           | Engineering and maintenance       |
	| 610  | Surveying technician                                          | Engineering and maintenance       |
	| 611  | TV or film sound technician                                   | Engineering and maintenance       |
	| 612  | Technical brewer                                              | Engineering and maintenance       |
	| 613  | Telecoms engineer                                             | Engineering and maintenance       |
	| 614  | Thatcher                                                      | Engineering and maintenance       |
	| 615  | Thermal insulation engineer                                   | Engineering and maintenance       |
	| 616  | Toolmaker                                                     | Engineering and maintenance       |
	| 617  | Upholsterer                                                   | Engineering and maintenance       |
	| 618  | Vehicle body repairer                                         | Engineering and maintenance       |
	| 619  | Vending machine operator                                      | Engineering and maintenance       |
	| 620  | Watch or clock repairer                                       | Engineering and maintenance       |
	| 621  | Water network operative                                       | Engineering and maintenance       |
	| 622  | Water treatment worker                                        | Engineering and maintenance       |
	| 623  | Wind turbine technician                                       | Engineering and maintenance       |
	| 624  | Window fitter                                                 | Engineering and maintenance       |
	| 625  | Windscreen fitter                                             | Engineering and maintenance       |
	| 626  | Agricultural contractor                                       | Environment and land              |
	| 627  | Agricultural engineer                                         | Environment and land              |
	| 628  | Agricultural engineering technician                           | Environment and land              |
	| 629  | Agricultural inspector                                        | Environment and land              |
	| 630  | Agronomist                                                    | Environment and land              |
	| 631  | Arboricultural officer                                        | Environment and land              |
	| 632  | Archaeologist                                                 | Environment and land              |
	| 633  | Bin worker                                                    | Environment and land              |
	| 634  | Biologist                                                     | Environment and land              |
	| 635  | Building technician                                           | Environment and land              |
	| 636  | Cartographer                                                  | Environment and land              |
	| 637  | Cemetery worker                                               | Environment and land              |
	| 638  | Chemical engineer                                             | Environment and land              |
	| 639  | Climate scientist                                             | Environment and land              |
	| 640  | Commercial energy assessor                                    | Environment and land              |
	| 641  | Corporate responsibility and sustainability practitioner      | Environment and land              |
	| 642  | Countryside officer                                           | Environment and land              |
	| 643  | Countryside ranger                                            | Environment and land              |
	| 644  | Drone pilot                                                   | Environment and land              |
	| 645  | Ecologist                                                     | Environment and land              |
	| 646  | Energy engineer                                               | Environment and land              |
	| 647  | Environmental consultant                                      | Environment and land              |
	| 648  | Environmental health officer                                  | Environment and land              |
	| 649  | Farm worker                                                   | Environment and land              |
	| 650  | Farmer                                                        | Environment and land              |
	| 651  | Fence installer                                               | Environment and land              |
	| 652  | Fish farmer                                                   | Environment and land              |
	| 653  | Florist                                                       | Environment and land              |
	| 654  | Food manufacturing inspector                                  | Environment and land              |
	| 655  | Forestry worker                                               | Environment and land              |
	| 656  | Gamekeeper                                                    | Environment and land              |
	| 657  | Gardener                                                      | Environment and land              |
	| 658  | Geoscientist                                                  | Environment and land              |
	| 659  | Geospatial technician                                         | Environment and land              |
	| 660  | Geotechnician                                                 | Environment and land              |
	| 661  | Groundsperson                                                 | Environment and land              |
	| 662  | Horticultural manager                                         | Environment and land              |
	| 663  | Horticultural therapist                                       | Environment and land              |
	| 664  | Horticultural worker                                          | Environment and land              |
	| 665  | Hydrologist                                                   | Environment and land              |
	| 666  | Land surveyor                                                 | Environment and land              |
	| 667  | Landscape architect                                           | Environment and land              |
	| 668  | Landscaper                                                    | Environment and land              |
	| 669  | Marine engineer                                               | Environment and land              |
	| 670  | Meat hygiene inspector                                        | Environment and land              |
	| 671  | Meteorologist                                                 | Environment and land              |
	| 672  | Nuclear engineer                                              | Environment and land              |
	| 673  | Oceanographer                                                 | Environment and land              |
	| 674  | Oil and gas operations manager                                | Environment and land              |
	| 675  | Palaeontologist                                               | Environment and land              |
	| 676  | Pest control technician                                       | Environment and land              |
	| 677  | Quarry engineer                                               | Environment and land              |
	| 678  | Recycled metals worker                                        | Environment and land              |
	| 679  | Recycling officer                                             | Environment and land              |
	| 680  | Research scientist                                            | Environment and land              |
	| 681  | Rural surveyor                                                | Environment and land              |
	| 682  | Seismologist                                                  | Environment and land              |
	| 683  | Thermal insulation engineer                                   | Environment and land              |
	| 684  | Tractor driver                                                | Environment and land              |
	| 685  | Tree surgeon                                                  | Environment and land              |
	| 686  | Water network operative                                       | Environment and land              |
	| 687  | Water treatment worker                                        | Environment and land              |
	| 688  | Wind turbine technician                                       | Environment and land              |
	| 689  | Zoologist                                                     | Environment and land              |
	| 690  | Air accident investigator                                     | Government services               |
	| 691  | Army officer                                                  | Government services               |
	| 692  | Assistant immigration officer                                 | Government services               |
	| 693  | Bodyguard                                                     | Government services               |
	| 694  | Border Force officer                                          | Government services               |
	| 695  | Careers adviser                                               | Government services               |
	| 696  | Cemetery worker                                               | Government services               |
	| 697  | Chief inspector                                               | Government services               |
	| 698  | Child protection officer                                      | Government services               |
	| 699  | Civil Service administrative officer                          | Government services               |
	| 700  | Civil Service executive officer                               | Government services               |
	| 701  | Civil Service manager                                         | Government services               |
	| 702  | Civil enforcement officer                                     | Government services               |
	| 703  | Coastguard                                                    | Government services               |
	| 704  | Criminologist                                                 | Government services               |
	| 705  | Data scientist                                                | Government services               |
	| 706  | Diplomatic Service officer                                    | Government services               |
	| 707  | Diver                                                         | Government services               |
	| 708  | Dog handler                                                   | Government services               |
	| 709  | Environmental health officer                                  | Government services               |
	| 710  | Fingerprint officer                                           | Government services               |
	| 711  | Food manufacturing inspector                                  | Government services               |
	| 712  | Forensic collision investigator                               | Government services               |
	| 713  | Heritage officer                                              | Government services               |
	| 714  | Housing policy officer                                        | Government services               |
	| 715  | Immigration officer                                           | Government services               |
	| 716  | Intelligence analyst                                          | Government services               |
	| 717  | MP                                                            | Government services               |
	| 718  | Merchant Navy engineering officer                             | Government services               |
	| 719  | Museum attendant                                              | Government services               |
	| 720  | Neighbourhood warden                                          | Government services               |
	| 721  | Ofsted inspector                                              | Government services               |
	| 722  | Police community support officer                              | Government services               |
	| 723  | Police officer                                                | Government services               |
	| 724  | Prison governor                                               | Government services               |
	| 725  | Prison instructor                                             | Government services               |
	| 726  | Probation officer                                             | Government services               |
	| 727  | Probation services officer                                    | Government services               |
	| 728  | RAF airman or airwoman                                        | Government services               |
	| 729  | RAF non-commissioned aircrew                                  | Government services               |
	| 730  | RAF officer                                                   | Government services               |
	| 731  | Recycling operative                                           | Government services               |
	| 732  | Registrar of births, deaths, marriages and civil partnerships | Government services               |
	| 733  | Royal Marines commando                                        | Government services               |
	| 734  | Royal Marines officer                                         | Government services               |
	| 735  | Royal Navy officer                                            | Government services               |
	| 736  | Royal Navy rating                                             | Government services               |
	| 737  | Scenes of crime officer                                       | Government services               |
	| 738  | School crossing patrol                                        | Government services               |
	| 739  | Security Service personnel                                    | Government services               |
	| 740  | Soldier                                                       | Government services               |
	| 741  | Recycled metals worker                                        | Government services               |
	| 742  | Recycling officer                                             | Government services               |
	| 743  | Research scientist                                            | Government services               |
	| 744  | Rural surveyor                                                | Government services               |
	| 745  | Seismologist                                                  | Government services               |
	| 746  | Thermal insulation engineer                                   | Government services               |
	| 747  | Tractor driver                                                | Government services               |
	| 748  | Tree surgeon                                                  | Government services               |
	| 749  | Water network operative                                       | Government services               |
	| 750  | Water treatment worker                                        | Government services               |
	| 751  | Wind turbine technician                                       | Government services               |
	| 752  | Zoologist                                                     | Government services               |
	| 753  | Acoustics consultant                                          | Healthcare                        |
	| 754  | Acupuncturist                                                 | Healthcare                        |
	| 755  | Ambulance care assistant                                      | Healthcare                        |
	| 756  | Anaesthetist                                                  | Healthcare                        |
	| 757  | Anatomical pathology technician                               | Healthcare                        |
	| 758  | Art therapist                                                 | Healthcare                        |
	| 759  | Audiologist                                                   | Healthcare                        |
	| 760  | Biomedical scientist                                          | Healthcare                        |
	| 761  | Care home advocate                                            | Healthcare                        |
	| 762  | Care worker                                                   | Healthcare                        |
	| 763  | Children's nurse                                              | Healthcare                        |
	| 764  | Chiropractor                                                  | Healthcare                        |
	| 765  | Clinical engineer                                             | Healthcare                        |
	| 766  | Clinical psychologist                                         | Healthcare                        |
	| 767  | Clinical scientist                                            | Healthcare                        |
	| 768  | Cognitive behavioural therapist                               | Healthcare                        |
	| 769  | Community matron                                              | Healthcare                        |
	| 770  | Cosmetic surgeon                                              | Healthcare                        |
	| 771  | Counsellor                                                    | Healthcare                        |
	| 772  | Critical care technologist                                    | Healthcare                        |
	| 773  | Dance movement psychotherapist                                | Healthcare                        |
	| 774  | Dental hygienist                                              | Healthcare                        |
	| 775  | Dental nurse                                                  | Healthcare                        |
	| 776  | Dental technician                                             | Healthcare                        |
	| 777  | Dental therapist                                              | Healthcare                        |
	| 778  | Dentist                                                       | Healthcare                        |
	| 779  | Dietitian                                                     | Healthcare                        |
	| 780  | Dispensing optician                                           | Healthcare                        |
	| 781  | District nurse                                                | Healthcare                        |
	| 782  | Dramatherapist                                                | Healthcare                        |
	| 783  | Emergency care assistant                                      | Healthcare                        |
	| 784  | Emergency medical dispatcher                                  | Healthcare                        |
	| 785  | GP                                                            | Healthcare                        |
	| 786  | Geneticist                                                    | Healthcare                        |
	| 787  | Health play specialist                                        | Healthcare                        |
	| 788  | Health promotion specialist                                   | Healthcare                        |
	| 789  | Health service manager                                        | Healthcare                        |
	| 790  | Health trainer                                                | Healthcare                        |
	| 791  | Health visitor                                                | Healthcare                        |
	| 792  | Healthcare assistant                                          | Healthcare                        |
	| 793  | Healthcare science assistant                                  | Healthcare                        |
	| 794  | Homeopath                                                     | Healthcare                        |
	| 795  | Hospital doctor                                               | Healthcare                        |
	| 796  | Hospital porter                                               | Healthcare                        |
	| 797  | Hypnotherapist                                                | Healthcare                        |
	| 798  | Learning disability nurse                                     | Healthcare                        |
	| 799  | Maternity support worker                                      | Healthcare                        |
	| 800  | Medical herbalist                                             | Healthcare                        |
	| 801  | Medical illustrator                                           | Healthcare                        |
	| 802  | Medical physicist                                             | Healthcare                        |
	| 803  | Mental health nurse                                           | Healthcare                        |
	| 804  | Microbiologist                                                | Healthcare                        |
	| 805  | Midwife                                                       | Healthcare                        |
	| 806  | Music therapist                                               | Healthcare                        |
	| 807  | Naturopath                                                    | Healthcare                        |
	| 808  | Nurse                                                         | Healthcare                        |
	| 809  | Nursing associate                                             | Healthcare                        |
	| 810  | Nutritional therapist                                         | Healthcare                        |
	| 811  | Nutritionist                                                  | Healthcare                        |
	| 812  | Occupational health nurse                                     | Healthcare                        |
	| 813  | Occupational therapist                                        | Healthcare                        |
	| 814  | Occupational therapy support worker                           | Healthcare                        |
	| 815  | Operating department practitioner                             | Healthcare                        |
	| 816  | Optometrist                                                   | Healthcare                        |
	| 817  | Orthoptist                                                    | Healthcare                        |
	| 818  | Osteopath                                                     | Healthcare                        |
	| 819  | Paediatrician                                                 | Healthcare                        |
	| 820  | Palliative care assistant                                     | Healthcare                        |
	| 821  | Paramedic                                                     | Healthcare                        |
	| 822  | Pathologist                                                   | Healthcare                        |
	| 823  | Patient advice and liaison service officer                    | Healthcare                        |
	| 824  | Patient transport service controller                          | Healthcare                        |
	| 825  | Pharmacist                                                    | Healthcare                        |
	| 826  | Pharmacologist                                                | Healthcare                        |
	| 827  | Pharmacy assistant                                            | Healthcare                        |
	| 828  | Pharmacy technician                                           | Healthcare                        |
	| 829  | Phlebotomist                                                  | Healthcare                        |
	| 830  | Physician associate                                           | Healthcare                        |
	| 831  | Physicist                                                     | Healthcare                        |
	| 832  | Physiotherapist                                               | Healthcare                        |
	| 833  | Physiotherapy assistant                                       | Healthcare                        |
	| 834  | Pilates teacher                                               | Healthcare                        |
	| 835  | Podiatrist                                                    | Healthcare                        |
	| 836  | Podiatry assistant                                            | Healthcare                        |
	| 837  | Practice nurse                                                | Healthcare                        |
	| 838  | Prosthetist-orthotist                                         | Healthcare                        |
	| 839  | Psychiatrist                                                  | Healthcare                        |
	| 840  | Psychological wellbeing practitioner                          | Healthcare                        |
	| 841  | Psychologist                                                  | Healthcare                        |
	| 842  | Psychotherapist                                               | Healthcare                        |
	| 843  | Radiographer                                                  | Healthcare                        |
	| 844  | Radiography assistant                                         | Healthcare                        |
	| 845  | Reiki healer                                                  | Healthcare                        |
	| 846  | School nurse                                                  | Healthcare                        |
	| 847  | Sonographer                                                   | Healthcare                        |
	| 848  | Speech and language therapist                                 | Healthcare                        |
	| 849  | Speech and language therapy assistant                         | Healthcare                        |
	| 850  | Sports development officer                                    | Healthcare                        |
	| 851  | Sports physiotherapist                                        | Healthcare                        |
	| 852  | Sterile services technician                                   | Healthcare                        |
	| 853  | Surgeon                                                       | Healthcare                        |
	| 854  | Yoga therapist                                                | Healthcare                        |
	| 855  | Accommodation warden                                          | Home services                     |
	| 856  | Bin worker                                                    | Home services                     |
	| 857  | Bodyguard                                                     | Home services                     |
	| 858  | British Sign Language interpreter                             | Home services                     |
	| 859  | Butler                                                        | Home services                     |
	| 860  | Care escort                                                   | Home services                     |
	| 861  | Care worker                                                   | Home services                     |
	| 862  | Caretaker                                                     | Home services                     |
	| 863  | Celebrant                                                     | Home services                     |
	| 864  | Chauffeur                                                     | Home services                     |
	| 865  | Chimney sweep                                                 | Home services                     |
	| 866  | Cleaner                                                       | Home services                     |
	| 867  | Community transport driver                                    | Home services                     |
	| 868  | Crematorium technician                                        | Home services                     |
	| 869  | Domestic energy assessor                                      | Home services                     |
	| 870  | Dry cleaner                                                   | Home services                     |
	| 871  | Embalmer                                                      | Home services                     |
	| 872  | Handyperson                                                   | Home services                     |
	| 873  | Highways cleaner                                              | Home services                     |
	| 874  | Industrial cleaner                                            | Home services                     |
	| 875  | Laundry worker                                                | Home services                     |
	| 876  | Life coach                                                    | Home services                     |
	| 877  | Personal shopper                                              | Home services                     |
	| 878  | Pest control technician                                       | Home services                     |
	| 879  | Postperson                                                    | Home services                     |
	| 880  | Recycled metals worker                                        | Home services                     |
	| 881  | Recycling operative                                           | Home services                     |
	| 882  | Religious leader                                              | Home services                     |
	| 883  | Satellite engineer                                            | Home services                     |
	| 884  | Tailor                                                        | Home services                     |
	| 885  | Wedding planner                                               | Home services                     |
	| 886  | Window cleaner                                                | Home services                     |
	| 887  | Baker                                                         | Hospitality and food              |
	| 888  | Bar person                                                    | Hospitality and food              |
	| 889  | Barista                                                       | Hospitality and food              |
	| 890  | Butcher                                                       | Hospitality and food              |
	| 891  | Butler                                                        | Hospitality and food              |
	| 892  | Cake decorator                                                | Hospitality and food              |
	| 893  | Catering manager                                              | Hospitality and food              |
	| 894  | Cellar technician                                             | Hospitality and food              |
	| 895  | Chef                                                          | Hospitality and food              |
	| 896  | Consumer scientist                                            | Hospitality and food              |
	| 897  | Counter service assistant                                     | Hospitality and food              |
	| 898  | Cruise ship steward                                           | Hospitality and food              |
	| 899  | Fishmonger                                                    | Hospitality and food              |
	| 900  | Food factory worker                                           | Hospitality and food              |
	| 901  | Food manufacturing inspector                                  | Hospitality and food              |
	| 902  | Food scientist                                                | Hospitality and food              |
	| 903  | Head chef                                                     | Hospitality and food              |
	| 904  | Hotel manager                                                 | Hospitality and food              |
	| 905  | Hotel porter                                                  | Hospitality and food              |
	| 906  | Hotel room attendant                                          | Hospitality and food              |
	| 907  | Housekeeper                                                   | Hospitality and food              |
	| 908  | Kitchen porter                                                | Hospitality and food              |
	| 909  | Meat process worker                                           | Hospitality and food              |
	| 910  | Microbrewer                                                   | Hospitality and food              |
	| 911  | Publican                                                      | Hospitality and food              |
	| 912  | Restaurant manager                                            | Hospitality and food              |
	| 913  | School lunchtime supervisor                                   | Hospitality and food              |
	| 914  | Street food trader                                            | Hospitality and food              |
	| 915  | Waiter                                                        | Hospitality and food              |
	| 916  | Wedding planner                                               | Hospitality and food              |
	| 917  | Bailiff                                                       | Law and legal                     |
	| 918  | Barrister                                                     | Law and legal                     |
	| 919  | Barristers' clerk                                             | Law and legal                     |
	| 920  | Company secretary                                             | Law and legal                     |
	| 921  | Coroner                                                       | Law and legal                     |
	| 922  | Court administrative assistant                                | Law and legal                     |
	| 923  | Court legal adviser                                           | Law and legal                     |
	| 924  | Court usher                                                   | Law and legal                     |
	| 925  | Credit controller                                             | Law and legal                     |
	| 926  | Crown prosecutor                                              | Law and legal                     |
	| 927  | Equalities officer                                            | Law and legal                     |
	| 928  | Family mediator                                               | Law and legal                     |
	| 929  | Forensic psychologist                                         | Law and legal                     |
	| 930  | Forensic scientist                                            | Law and legal                     |
	| 931  | Immigration adviser (non-government)                          | Law and legal                     |
	| 932  | Interpreter                                                   | Law and legal                     |
	| 933  | Judge                                                         | Law and legal                     |
	| 934  | Legal executive                                               | Law and legal                     |
	| 935  | Legal secretary                                               | Law and legal                     |
	| 936  | Licensed conveyancer                                          | Law and legal                     |
	| 937  | Magistrate                                                    | Law and legal                     |
	| 938  | Paralegal                                                     | Law and legal                     |
	| 939  | Patent attorney                                               | Law and legal                     |
	| 940  | Probation officer                                             | Law and legal                     |
	| 941  | Probation services officer                                    | Law and legal                     |
	| 942  | Proofreader                                                   | Law and legal                     |
	| 943  | Solicitor                                                     | Law and legal                     |
	| 944  | Tax inspector                                                 | Law and legal                     |
	| 945  | Trade mark attorney                                           | Law and legal                     |
	| 946  | Trading standards officer                                     | Law and legal                     |
	| 947  | Victim care officer                                           | Law and legal                     |
	| 948  | Welfare rights officer                                        | Law and legal                     |
	| 949  | Advertising account executive                                 | Managerial                        |
	| 950  | Advertising media planner                                     | Managerial                        |
	| 951  | Bank manager                                                  | Managerial                        |
	| 952  | Bid writer                                                    | Managerial                        |
	| 953  | Building control officer                                      | Managerial                        |
	| 954  | Business adviser                                              | Managerial                        |
	| 955  | Business analyst                                              | Managerial                        |
	| 956  | Business development manager                                  | Managerial                        |
	| 957  | Business project manager                                      | Managerial                        |
	| 958  | Care home manager                                             | Managerial                        |
	| 959  | Charity director                                              | Managerial                        |
	| 960  | Charity fundraiser                                            | Managerial                        |
	| 961  | Chief executive                                               | Managerial                        |
	| 962  | Chief inspector                                               | Managerial                        |
	| 963  | Civil Service executive officer                               | Managerial                        |
	| 964  | Civil Service manager                                         | Managerial                        |
	| 965  | Community education co-ordinator                              | Managerial                        |
	| 966  | Company secretary                                             | Managerial                        |
	| 967  | Construction contracts manager                                | Managerial                        |
	| 968  | Construction manager                                          | Managerial                        |
	| 969  | Consumer scientist                                            | Managerial                        |
	| 970  | Credit manager                                                | Managerial                        |
	| 971  | Customer services manager                                     | Managerial                        |
	| 972  | Digital delivery manager                                      | Managerial                        |
	| 973  | Diplomatic Service officer                                    | Managerial                        |
	| 974  | E-commerce manager                                            | Managerial                        |
	| 975  | Economic development officer                                  | Managerial                        |
	| 976  | Economist                                                     | Managerial                        |
	| 977  | Environmental consultant                                      | Managerial                        |
	| 978  | Estates officer                                               | Managerial                        |
	| 979  | Estimator                                                     | Managerial                        |
	| 980  | Events manager                                                | Managerial                        |
	| 981  | Facilities manager                                            | Managerial                        |
	| 982  | Farmer                                                        | Managerial                        |
	| 983  | Franchise owner                                               | Managerial                        |
	| 984  | GP practice manager                                           | Managerial                        |
	| 985  | Garage manager                                                | Managerial                        |
	| 986  | General practice surveyor                                     | Managerial                        |
	| 987  | Headteacher                                                   | Managerial                        |
	| 988  | Health and safety adviser                                     | Managerial                        |
	| 989  | Health service manager                                        | Managerial                        |
	| 990  | Horticultural manager                                         | Managerial                        |
	| 991  | Hotel manager                                                 | Managerial                        |
	| 992  | Housing officer                                               | Managerial                        |
	| 993  | Housing policy officer                                        | Managerial                        |
	| 994  | Human resources officer                                       | Managerial                        |
	| 995  | Leisure centre manager                                        | Managerial                        |
	| 996  | MP                                                            | Managerial                        |
	| 997  | Management accountant                                         | Managerial                        |
	| 998  | Management consultant                                         | Managerial                        |
	| 999  | Marketing manager                                             | Managerial                        |
	| 1000 | Museum curator                                                | Managerial                        |
	| 1001 | Network manager                                               | Managerial                        |
	| 1002 | Nursery manager                                               | Managerial                        |
	| 1003 | Office manager                                                | Managerial                        |
	| 1004 | Oil and gas operations manager                                | Managerial                        |
	| 1005 | Operational researcher                                        | Managerial                        |
	| 1006 | Payroll manager                                               | Managerial                        |
	| 1007 | Planning and development surveyor                             | Managerial                        |
	| 1008 | Private practice accountant                                   | Managerial                        |
	| 1009 | Production manager (manufacturing)                            | Managerial                        |
	| 1010 | Public relations director                                     | Managerial                        |
	| 1011 | Purchasing manager                                            | Managerial                        |
	| 1012 | Quality assurance manager                                     | Managerial                        |
	| 1013 | Quantity surveyor                                             | Managerial                        |
	| 1014 | Retail manager                                                | Managerial                        |
	| 1015 | Rural surveyor                                                | Managerial                        |
	| 1016 | Sales manager                                                 | Managerial                        |
	| 1017 | Security Service personnel                                    | Managerial                        |
	| 1018 | Social services manager                                       | Managerial                        |
	| 1019 | Supervisor                                                    | Managerial                        |
	| 1020 | Supply chain manager                                          | Managerial                        |
	| 1021 | Surveying technician                                          | Managerial                        |
	| 1022 | TV or film producer                                           | Managerial                        |
	| 1023 | Tax inspector                                                 | Managerial                        |
	| 1024 | Technical architect                                           | Managerial                        |
	| 1025 | Textiles production manager                                   | Managerial                        |
	| 1026 | Tour manager                                                  | Managerial                        |
	| 1027 | Town planner                                                  | Managerial                        |
	| 1028 | Training manager                                              | Managerial                        |
	| 1029 | Transport planner                                             | Managerial                        |
	| 1030 | Travel agency manager                                         | Managerial                        |
	| 1031 | Visitor attraction general manager                            | Managerial                        |
	| 1032 | Warehouse manager                                             | Managerial                        |
	| 1033 | Wedding planner                                               | Managerial                        |
	| 1034 | 3D printing technician                                        | Manufacturing                     |
	| 1035 | Aerospace engineer                                            | Manufacturing                     |
	| 1036 | Aerospace engineering technician                              | Manufacturing                     |
	| 1037 | Agricultural engineer                                         | Manufacturing                     |
	| 1038 | Agricultural engineering technician                           | Manufacturing                     |
	| 1039 | Automotive engineer                                           | Manufacturing                     |
	| 1040 | Blacksmith                                                    | Manufacturing                     |
	| 1041 | Bottler                                                       | Manufacturing                     |
	| 1042 | Building services engineer                                    | Manufacturing                     |
	| 1043 | CNC machinist                                                 | Manufacturing                     |
	| 1044 | Car manufacturing worker                                      | Manufacturing                     |
	| 1045 | Chemical engineer                                             | Manufacturing                     |
	| 1046 | Chemical engineering technician                               | Manufacturing                     |
	| 1047 | Chemical plant process operator                               | Manufacturing                     |
	| 1048 | Crane driver                                                  | Manufacturing                     |
	| 1049 | Design and development engineer                               | Manufacturing                     |
	| 1050 | Dressmaker                                                    | Manufacturing                     |
	| 1051 | Electronics engineer                                          | Manufacturing                     |
	| 1052 | Energy engineer                                               | Manufacturing                     |
	| 1053 | Engineering construction technician                           | Manufacturing                     |
	| 1054 | Engineering craft machinist                                   | Manufacturing                     |
	| 1055 | Engineering maintenance technician                            | Manufacturing                     |
	| 1056 | Engineering operative                                         | Manufacturing                     |
	| 1057 | Food packaging operative                                      | Manufacturing                     |
	| 1058 | Food scientist                                                | Manufacturing                     |
	| 1059 | Footwear manufacturing operative                              | Manufacturing                     |
	| 1060 | Foundry mould maker                                           | Manufacturing                     |
	| 1061 | Foundry process operator                                      | Manufacturing                     |
	| 1062 | Garment technologist                                          | Manufacturing                     |
	| 1063 | Glassmaker                                                    | Manufacturing                     |
	| 1064 | Knitting machinist                                            | Manufacturing                     |
	| 1065 | Leather craftworker                                           | Manufacturing                     |
	| 1066 | Leather technologist                                          | Manufacturing                     |
	| 1067 | Maintenance fitter                                            | Manufacturing                     |
	| 1068 | Manufacturing systems engineer                                | Manufacturing                     |
	| 1069 | Marine engineer                                               | Manufacturing                     |
	| 1070 | Materials engineer                                            | Manufacturing                     |
	| 1071 | Materials technician                                          | Manufacturing                     |
	| 1072 | Meat process worker                                           | Manufacturing                     |
	| 1073 | Mechanical engineering technician                             | Manufacturing                     |
	| 1074 | Metrologist                                                   | Manufacturing                     |
	| 1075 | Microbrewer                                                   | Manufacturing                     |
	| 1076 | Motor mechanic                                                | Manufacturing                     |
	| 1077 | Motorsport engineer                                           | Manufacturing                     |
	| 1078 | Musical instrument maker and repairer                         | Manufacturing                     |
	| 1079 | Naval architect                                               | Manufacturing                     |
	| 1080 | Non-destructive testing technician                            | Manufacturing                     |
	| 1081 | Packaging technologist                                        | Manufacturing                     |
	| 1082 | Packer                                                        | Manufacturing                     |
	| 1083 | Paint sprayer                                                 | Manufacturing                     |
	| 1084 | Paper maker                                                   | Manufacturing                     |
	| 1085 | Patent attorney                                               | Manufacturing                     |
	| 1086 | Pattern cutter                                                | Manufacturing                     |
	| 1087 | Product designer                                              | Manufacturing                     |
	| 1088 | Production manager (manufacturing)                            | Manufacturing                     |
	| 1089 | Production worker (manufacturing)                             | Manufacturing                     |
	| 1090 | Quality control assistant                                     | Manufacturing                     |
	| 1091 | Quarry worker                                                 | Manufacturing                     |
	| 1092 | Recycling operative                                           | Manufacturing                     |
	| 1093 | Reprographic assistant                                        | Manufacturing                     |
	| 1094 | Rolling stock engineering technician                          | Manufacturing                     |
	| 1095 | Roustabout                                                    | Manufacturing                     |
	| 1096 | Sewing machinist                                              | Manufacturing                     |
	| 1097 | Signmaker                                                     | Manufacturing                     |
	| 1098 | Technical brewer                                              | Manufacturing                     |
	| 1099 | Technical textiles designer                                   | Manufacturing                     |
	| 1100 | Textile dyeing technician                                     | Manufacturing                     |
	| 1101 | Textile operative                                             | Manufacturing                     |
	| 1102 | Textiles production manager                                   | Manufacturing                     |
	| 1103 | Toolmaker                                                     | Manufacturing                     |
	| 1104 | Vehicle body repairer                                         | Manufacturing                     |
	| 1105 | Welder                                                        | Manufacturing                     |
	| 1106 | Window fabricator                                             | Manufacturing                     |
	| 1107 | Wood machinist                                                | Manufacturing                     |
	| 1108 | Advertising account executive                                 | Retail and sales                  |
	| 1109 | Advertising account planner                                   | Retail and sales                  |
	| 1110 | Advertising media buyer                                       | Retail and sales                  |
	| 1111 | Airline customer service agent                                | Retail and sales                  |
	| 1112 | Airport information assistant                                 | Retail and sales                  |
	| 1113 | Antique dealer                                                | Retail and sales                  |
	| 1114 | Art valuer                                                    | Retail and sales                  |
	| 1115 | Banking customer service adviser                              | Retail and sales                  |
	| 1116 | Bar person                                                    | Retail and sales                  |
	| 1117 | Barista                                                       | Retail and sales                  |
	| 1118 | Beauty consultant                                             | Retail and sales                  |
	| 1119 | Bookmaker                                                     | Retail and sales                  |
	| 1120 | Bookseller                                                    | Retail and sales                  |
	| 1121 | Builders' merchant                                            | Retail and sales                  |
	| 1122 | Business analyst                                              | Retail and sales                  |
	| 1123 | Business development manager                                  | Retail and sales                  |
	| 1124 | Butcher                                                       | Retail and sales                  |
	| 1125 | Cabin crew                                                    | Retail and sales                  |
	| 1126 | Call centre operator                                          | Retail and sales                  |
	| 1127 | Car rental agent                                              | Retail and sales                  |
	| 1128 | Cinema or theatre attendant                                   | Retail and sales                  |
	| 1129 | Construction plant hire adviser                               | Retail and sales                  |
	| 1130 | Customer service assistant                                    | Retail and sales                  |
	| 1131 | Customer services manager                                     | Retail and sales                  |
	| 1132 | E-commerce manager                                            | Retail and sales                  |
	| 1133 | Emergency medical dispatcher                                  | Retail and sales                  |
	| 1134 | Estate agent                                                  | Retail and sales                  |
	| 1135 | Events manager                                                | Retail and sales                  |
	| 1136 | Fishmonger                                                    | Retail and sales                  |
	| 1137 | Florist                                                       | Retail and sales                  |
	| 1138 | Franchise owner                                               | Retail and sales                  |
	| 1139 | Horticultural manager                                         | Retail and sales                  |
	| 1140 | Insurance account manager                                     | Retail and sales                  |
	| 1141 | Land and property valuer and auctioneer                       | Retail and sales                  |
	| 1142 | Leisure centre assistant                                      | Retail and sales                  |
	| 1143 | Letting agent                                                 | Retail and sales                  |
	| 1144 | Market research executive                                     | Retail and sales                  |
	| 1145 | Market trader                                                 | Retail and sales                  |
	| 1146 | Marketing executive                                           | Retail and sales                  |
	| 1147 | Marketing manager                                             | Retail and sales                  |
	| 1148 | Medical sales representative                                  | Retail and sales                  |
	| 1149 | Motor vehicle parts person                                    | Retail and sales                  |
	| 1150 | Museum attendant                                              | Retail and sales                  |
	| 1151 | Music promotions manager                                      | Retail and sales                  |
	| 1152 | Personal shopper                                              | Retail and sales                  |
	| 1153 | Pet shop assistant                                            | Retail and sales                  |
	| 1154 | Pharmacist                                                    | Retail and sales                  |
	| 1155 | Pharmacy assistant                                            | Retail and sales                  |
	| 1156 | Pharmacy technician                                           | Retail and sales                  |
	| 1157 | Post Office customer service assistant                        | Retail and sales                  |
	| 1158 | Public relations director                                     | Retail and sales                  |
	| 1159 | Retail buyer                                                  | Retail and sales                  |
	| 1160 | Retail manager                                                | Retail and sales                  |
	| 1161 | Retail merchandiser                                           | Retail and sales                  |
	| 1162 | Sales administrator                                           | Retail and sales                  |
	| 1163 | Sales assistant                                               | Retail and sales                  |
	| 1164 | Sales manager                                                 | Retail and sales                  |
	| 1165 | Sales representative                                          | Retail and sales                  |
	| 1166 | Shelf filler                                                  | Retail and sales                  |
	| 1167 | Shopkeeper                                                    | Retail and sales                  |
	| 1168 | Stock control assistant                                       | Retail and sales                  |
	| 1169 | Telephonist                                                   | Retail and sales                  |
	| 1170 | Tourist information centre assistant                          | Retail and sales                  |
	| 1171 | Train station worker                                          | Retail and sales                  |
	| 1172 | Travel agent                                                  | Retail and sales                  |
	| 1173 | Vending machine operator                                      | Retail and sales                  |
	| 1174 | Visual merchandiser                                           | Retail and sales                  |
	| 1175 | Wine merchant                                                 | Retail and sales                  |
	| 1176 | Acoustics consultant                                          | Science and research              |
	| 1177 | Agronomist                                                    | Science and research              |
	| 1178 | Animal technician                                             | Science and research              |
	| 1179 | Arboricultural officer                                        | Science and research              |
	| 1180 | Archaeologist                                                 | Science and research              |
	| 1181 | Astronaut                                                     | Science and research              |
	| 1182 | Astronomer                                                    | Science and research              |
	| 1183 | Audiologist                                                   | Science and research              |
	| 1184 | Biochemist                                                    | Science and research              |
	| 1185 | Biologist                                                     | Science and research              |
	| 1186 | Biomedical scientist                                          | Science and research              |
	| 1187 | Biotechnologist                                               | Science and research              |
	| 1188 | Cartographer                                                  | Science and research              |
	| 1189 | Chemical engineer                                             | Science and research              |
	| 1190 | Chemical engineering technician                               | Science and research              |
	| 1191 | Chemist                                                       | Science and research              |
	| 1192 | Climate scientist                                             | Science and research              |
	| 1193 | Clinical engineer                                             | Science and research              |
	| 1194 | Clinical psychologist                                         | Science and research              |
	| 1195 | Clinical scientist                                            | Science and research              |
	| 1196 | Consumer scientist                                            | Science and research              |
	| 1197 | Countryside officer                                           | Science and research              |
	| 1198 | Data analyst-statistician                                     | Science and research              |
	| 1199 | Data scientist                                                | Science and research              |
	| 1200 | Ecologist                                                     | Science and research              |
	| 1201 | Economist                                                     | Science and research              |
	| 1202 | Education technician                                          | Science and research              |
	| 1203 | Electronics engineer                                          | Science and research              |
	| 1204 | Energy engineer                                               | Science and research              |
	| 1205 | Environmental consultant                                      | Science and research              |
	| 1206 | Fingerprint officer                                           | Science and research              |
	| 1207 | Food scientist                                                | Science and research              |
	| 1208 | Forensic scientist                                            | Science and research              |
	| 1209 | Garment technologist                                          | Science and research              |
	| 1210 | Geneticist                                                    | Science and research              |
	| 1211 | Geoscientist                                                  | Science and research              |
	| 1212 | Geospatial technician                                         | Science and research              |
	| 1213 | Geotechnician                                                 | Science and research              |
	| 1214 | Healthcare science assistant                                  | Science and research              |
	| 1215 | Housing policy officer                                        | Science and research              |
	| 1216 | Hydrologist                                                   | Science and research              |
	| 1217 | Intelligence analyst                                          | Science and research              |
	| 1218 | Laboratory technician                                         | Science and research              |
	| 1219 | Land surveyor                                                 | Science and research              |
	| 1220 | Marine engineer                                               | Science and research              |
	| 1221 | Market research data analyst                                  | Science and research              |
	| 1222 | Market researcher                                             | Science and research              |
	| 1223 | Materials engineer                                            | Science and research              |
	| 1224 | Materials technician                                          | Science and research              |
	| 1225 | Medical physicist                                             | Science and research              |
	| 1226 | Meteorologist                                                 | Science and research              |
	| 1227 | Metrologist                                                   | Science and research              |
	| 1228 | Microbiologist                                                | Science and research              |
	| 1229 | Nanotechnologist                                              | Science and research              |
	| 1230 | Nuclear engineer                                              | Science and research              |
	| 1231 | Oceanographer                                                 | Science and research              |
	| 1232 | Operational researcher                                        | Science and research              |
	| 1233 | Palaeontologist                                               | Science and research              |
	| 1234 | Pathologist                                                   | Science and research              |
	| 1235 | Performance sports scientist                                  | Science and research              |
	| 1236 | Pet behaviour consultant                                      | Science and research              |
	| 1237 | Pharmacologist                                                | Science and research              |
	| 1238 | Physicist                                                     | Science and research              |
	| 1239 | Proofreader                                                   | Science and research              |
	| 1240 | Psychiatrist                                                  | Science and research              |
	| 1241 | Psychologist                                                  | Science and research              |
	| 1242 | Quarry engineer                                               | Science and research              |
	| 1243 | Research scientist                                            | Science and research              |
	| 1244 | Robotics engineer                                             | Science and research              |
	| 1245 | Scenes of crime officer                                       | Science and research              |
	| 1246 | Seismologist                                                  | Science and research              |
	| 1247 | Sport and exercise psychologist                               | Science and research              |
	| 1248 | Technical brewer                                              | Science and research              |
	| 1249 | Textile dyeing technician                                     | Science and research              |
	| 1250 | Vet                                                           | Science and research              |
	| 1251 | Zoologist                                                     | Science and research              |
	| 1252 | Accommodation warden                                          | Social care                       |
	| 1253 | Aid worker                                                    | Social care                       |
	| 1254 | Art therapist                                                 | Social care                       |
	| 1255 | British Sign Language interpreter                             | Social care                       |
	| 1256 | Care escort                                                   | Social care                       |
	| 1257 | Care home advocate                                            | Social care                       |
	| 1258 | Care home manager                                             | Social care                       |
	| 1259 | Care worker                                                   | Social care                       |
	| 1260 | Careers adviser                                               | Social care                       |
	| 1261 | Child protection officer                                      | Social care                       |
	| 1262 | Childminder                                                   | Social care                       |
	| 1263 | Clinical psychologist                                         | Social care                       |
	| 1264 | Cognitive behavioural therapist                               | Social care                       |
	| 1265 | Communication support worker                                  | Social care                       |
	| 1266 | Community development worker                                  | Social care                       |
	| 1267 | Community transport driver                                    | Social care                       |
	| 1268 | Counsellor                                                    | Social care                       |
	| 1269 | Dramatherapist                                                | Social care                       |
	| 1270 | Education welfare officer                                     | Social care                       |
	| 1271 | Equalities officer                                            | Social care                       |
	| 1272 | Family mediator                                               | Social care                       |
	| 1273 | Family support worker                                         | Social care                       |
	| 1274 | Forensic psychologist                                         | Social care                       |
	| 1275 | Foster carer                                                  | Social care                       |
	| 1276 | Funeral director                                              | Social care                       |
	| 1277 | Horticultural therapist                                       | Social care                       |
	| 1278 | Housing officer                                               | Social care                       |
	| 1279 | Learning mentor                                               | Social care                       |
	| 1280 | Life coach                                                    | Social care                       |
	| 1281 | Money adviser                                                 | Social care                       |
	| 1282 | Music therapist                                               | Social care                       |
	| 1283 | Nanny                                                         | Social care                       |
	| 1284 | Nursery manager                                               | Social care                       |
	| 1285 | Nursery worker                                                | Social care                       |
	| 1286 | Occupational therapist                                        | Social care                       |
	| 1287 | Occupational therapy support worker                           | Social care                       |
	| 1288 | Palliative care assistant                                     | Social care                       |
	| 1289 | Patient advice and liaison service officer                    | Social care                       |
	| 1290 | Play therapist                                                | Social care                       |
	| 1291 | Playworker                                                    | Social care                       |
	| 1292 | Probation officer                                             | Social care                       |
	| 1293 | Psychological wellbeing practitioner                          | Social care                       |
	| 1294 | Psychologist                                                  | Social care                       |
	| 1295 | Psychotherapist                                               | Social care                       |
	| 1296 | Religious leader                                              | Social care                       |
	| 1297 | Residential support worker                                    | Social care                       |
	| 1298 | School crossing patrol                                        | Social care                       |
	| 1299 | School houseparent                                            | Social care                       |
	| 1300 | Senior care worker                                            | Social care                       |
	| 1301 | Social services manager                                       | Social care                       |
	| 1302 | Social work assistant                                         | Social care                       |
	| 1303 | Social worker                                                 | Social care                       |
	| 1304 | Substance misuse outreach worker                              | Social care                       |
	| 1305 | Victim care officer                                           | Social care                       |
	| 1306 | Welfare rights officer                                        | Social care                       |
	| 1307 | Youth offending team officer                                  | Social care                       |
	| 1308 | Youth worker                                                  | Social care                       |
	| 1309 | Athlete                                                       | Sports and leisure                |
	| 1310 | Bookmaker                                                     | Sports and leisure                |
	| 1311 | Cinema or theatre attendant                                   | Sports and leisure                |
	| 1312 | Cycling coach                                                 | Sports and leisure                |
	| 1313 | Diver                                                         | Sports and leisure                |
	| 1314 | Events manager                                                | Sports and leisure                |
	| 1315 | Fitness instructor                                            | Sports and leisure                |
	| 1316 | Football coach                                                | Sports and leisure                |
	| 1317 | Football referee                                              | Sports and leisure                |
	| 1318 | Health trainer                                                | Sports and leisure                |
	| 1319 | Horse riding instructor                                       | Sports and leisure                |
	| 1320 | Housekeeper                                                   | Sports and leisure                |
	| 1321 | Jockey                                                        | Sports and leisure                |
	| 1322 | Leisure centre assistant                                      | Sports and leisure                |
	| 1323 | Leisure centre manager                                        | Sports and leisure                |
	| 1324 | Lifeguard                                                     | Sports and leisure                |
	| 1325 | Martial arts instructor                                       | Sports and leisure                |
	| 1326 | Motorsport engineer                                           | Sports and leisure                |
	| 1327 | Museum attendant                                              | Sports and leisure                |
	| 1328 | Outdoor activities instructor                                 | Sports and leisure                |
	| 1329 | PE teacher                                                    | Sports and leisure                |
	| 1330 | Performance sports scientist                                  | Sports and leisure                |
	| 1331 | Personal trainer                                              | Sports and leisure                |
	| 1332 | Pilates teacher                                               | Sports and leisure                |
	| 1333 | Racehorse trainer                                             | Sports and leisure                |
	| 1334 | Resort representative                                         | Sports and leisure                |
	| 1335 | Sailing instructor                                            | Sports and leisure                |
	| 1336 | Sport and exercise psychologist                               | Sports and leisure                |
	| 1337 | Sports coach                                                  | Sports and leisure                |
	| 1338 | Sports commentator                                            | Sports and leisure                |
	| 1339 | Sports development officer                                    | Sports and leisure                |
	| 1340 | Sports physiotherapist                                        | Sports and leisure                |
	| 1341 | Sports professional                                           | Sports and leisure                |
	| 1342 | Swimming teacher                                              | Sports and leisure                |
	| 1343 | Tourist information centre assistant                          | Sports and leisure                |
	| 1344 | Visitor attraction general manager                            | Sports and leisure                |
	| 1345 | Yoga teacher                                                  | Sports and leisure                |
	| 1346 | Audio-visual technician                                       | Teaching and education            |
	| 1347 | British Sign Language teacher                                 | Teaching and education            |
	| 1348 | Careers adviser                                               | Teaching and education            |
	| 1349 | Child protection officer                                      | Teaching and education            |
	| 1350 | Communication support worker                                  | Teaching and education            |
	| 1351 | Community education co-ordinator                              | Teaching and education            |
	| 1352 | Criminologist                                                 | Teaching and education            |
	| 1353 | Cycling coach                                                 | Teaching and education            |
	| 1354 | Dance teacher                                                 | Teaching and education            |
	| 1355 | E-learning developer                                          | Teaching and education            |
	| 1356 | Early years teacher                                           | Teaching and education            |
	| 1357 | Education technician                                          | Teaching and education            |
	| 1358 | Education welfare officer                                     | Teaching and education            |
	| 1359 | English as a foreign language (EFL) teacher                   | Teaching and education            |
	| 1360 | Equalities officer                                            | Teaching and education            |
	| 1361 | Further education lecturer                                    | Teaching and education            |
	| 1362 | Headteacher                                                   | Teaching and education            |
	| 1363 | Health promotion specialist                                   | Teaching and education            |
	| 1364 | Higher education lecturer                                     | Teaching and education            |
	| 1365 | Learning mentor                                               | Teaching and education            |
	| 1366 | Librarian                                                     | Teaching and education            |
	| 1367 | Library assistant                                             | Teaching and education            |
	| 1368 | Martial arts instructor                                       | Teaching and education            |
	| 1369 | Montessori teacher                                            | Teaching and education            |
	| 1370 | Museum curator                                                | Teaching and education            |
	| 1371 | Music teacher                                                 | Teaching and education            |
	| 1372 | Nursery worker                                                | Teaching and education            |
	| 1373 | Ofsted inspector                                              | Teaching and education            |
	| 1374 | Online tutor                                                  | Teaching and education            |
	| 1375 | Outdoor activities instructor                                 | Teaching and education            |
	| 1376 | PE teacher                                                    | Teaching and education            |
	| 1377 | Playworker                                                    | Teaching and education            |
	| 1378 | Portage home visitor                                          | Teaching and education            |
	| 1379 | Primary school teacher                                        | Teaching and education            |
	| 1380 | Prison instructor                                             | Teaching and education            |
	| 1381 | QCF assessor                                                  | Teaching and education            |
	| 1382 | Sailing instructor                                            | Teaching and education            |
	| 1383 | School business manager                                       | Teaching and education            |
	| 1384 | School crossing patrol                                        | Teaching and education            |
	| 1385 | School houseparent                                            | Teaching and education            |
	| 1386 | School lunchtime supervisor                                   | Teaching and education            |
	| 1387 | Secondary school teacher                                      | Teaching and education            |
	| 1388 | Skills for life teacher                                       | Teaching and education            |
	| 1389 | Special educational needs (SEN) teacher                       | Teaching and education            |
	| 1390 | Special educational needs (SEN) teaching assistant            | Teaching and education            |
	| 1391 | Swimming teacher                                              | Teaching and education            |
	| 1392 | Teaching assistant                                            | Teaching and education            |
	| 1393 | Trade union official                                          | Teaching and education            |
	| 1394 | Training manager                                              | Teaching and education            |
	| 1395 | Training officer                                              | Teaching and education            |
	| 1396 | Yoga teacher                                                  | Teaching and education            |
	| 1397 | Youth worker                                                  | Teaching and education            |
	| 1398 | Air accident investigator                                     | Transport                         |
	| 1399 | Air traffic controller                                        | Transport                         |
	| 1400 | Airline customer service agent                                | Transport                         |
	| 1401 | Airline pilot                                                 | Transport                         |
	| 1402 | Airport baggage handler                                       | Transport                         |
	| 1403 | Airport information assistant                                 | Transport                         |
	| 1404 | Ambulance care assistant                                      | Transport                         |
	| 1405 | Bus or coach driver                                           | Transport                         |
	| 1406 | Cabin crew                                                    | Transport                         |
	| 1407 | Car rental agent                                              | Transport                         |
	| 1408 | Car valet                                                     | Transport                         |
	| 1409 | Care escort                                                   | Transport                         |
	| 1410 | Chauffeur                                                     | Transport                         |
	| 1411 | Community transport driver                                    | Transport                         |
	| 1412 | Delivery van driver                                           | Transport                         |
	| 1413 | Driving instructor                                            | Transport                         |
	| 1414 | Fishing vessel skipper                                        | Transport                         |
	| 1415 | Forensic collision investigator                               | Transport                         |
	| 1416 | Forklift driver                                               | Transport                         |
	| 1417 | Garage manager                                                | Transport                         |
	| 1418 | Helicopter engineer                                           | Transport                         |
	| 1419 | Helicopter pilot                                              | Transport                         |
	| 1420 | Import-export clerk                                           | Transport                         |
	| 1421 | Large goods vehicle driver                                    | Transport                         |
	| 1422 | Merchant Navy deck officer                                    | Transport                         |
	| 1423 | Merchant Navy rating                                          | Transport                         |
	| 1424 | Motor vehicle parts person                                    | Transport                         |
	| 1425 | Patient transport service controller                          | Transport                         |
	| 1426 | Port operative                                                | Transport                         |
	| 1427 | Rail track maintenance worker                                 | Transport                         |
	| 1428 | Railway signaller                                             | Transport                         |
	| 1429 | Road transport manager                                        | Transport                         |
	| 1430 | Rolling stock engineering technician                          | Transport                         |
	| 1431 | Signalling technician                                         | Transport                         |
	| 1432 | Supply chain manager                                          | Transport                         |
	| 1433 | Tanker driver                                                 | Transport                         |
	| 1434 | Taxi driver                                                   | Transport                         |
	| 1435 | Tractor driver                                                | Transport                         |
	| 1436 | Train conductor                                               | Transport                         |
	| 1437 | Train driver                                                  | Transport                         |
	| 1438 | Train station worker                                          | Transport                         |
	| 1439 | Tram driver                                                   | Transport                         |
	| 1440 | Transport planner                                             | Transport                         |
	| 1441 | Windscreen fitter                                             | Transport                         |
	| 1442 | Airline customer service agent                                | Travel and tourism                |
	| 1443 | Airline pilot                                                 | Travel and tourism                |
	| 1444 | Airport information assistant                                 | Travel and tourism                |
	| 1445 | Cabin crew                                                    | Travel and tourism                |
	| 1446 | Cruise ship steward                                           | Travel and tourism                |
	| 1447 | Diver                                                         | Travel and tourism                |
	| 1448 | Heritage officer                                              | Travel and tourism                |
	| 1449 | Hotel manager                                                 | Travel and tourism                |
	| 1450 | Hotel porter                                                  | Travel and tourism                |
	| 1451 | Hotel room attendant                                          | Travel and tourism                |
	| 1452 | Housekeeper                                                   | Travel and tourism                |
	| 1453 | Interpreter                                                   | Travel and tourism                |
	| 1454 | Museum attendant                                              | Travel and tourism                |
	| 1455 | Port operative                                                | Travel and tourism                |
	| 1456 | Resort representative                                         | Travel and tourism                |
	| 1457 | Sailing instructor                                            | Travel and tourism                |
	| 1458 | Tour manager                                                  | Travel and tourism                |
	| 1459 | Tourist guide                                                 | Travel and tourism                |
	| 1460 | Tourist information centre assistant                          | Travel and tourism                |
	| 1461 | Travel agency manager                                         | Travel and tourism                |
	| 1462 | Travel agent                                                  | Travel and tourism                |
	| 1463 | Visitor attraction general manager                            | Travel and tourism                |