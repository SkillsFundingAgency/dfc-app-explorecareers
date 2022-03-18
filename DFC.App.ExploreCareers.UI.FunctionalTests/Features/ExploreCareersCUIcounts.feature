Feature: ExploreCareersCUIcounts
		I want to reconcile counts between the production environment and the test environment

Scenario Outline: Compare Job profile search counts in different environments
	Given I am at the "Search results" page
	And I search for the term <Job profile>
	And I obtain the number of search results
	And I surf to the "Production" environments "search results" page
	And I search for the term <Job profile>
	And I obtain the number of search results
	When I compare the number of search results from both environments
	Then the number is the same
Examples:
	| Job profile                                                   | Job category                      |
	| Admin assistant                                               | Administrator                     |
	| Arts administrator                                            | Administrator                     |
	| Assistant immigration officer                                 | Administrator                     |
	| Auditor                                                       | Administrator                     |
	| Bid writer                                                    | Administrator                     |
	| Bilingual secretary                                           | Administrator                     |
	| Bookkeeper                                                    | Administrator                     |
	| Border Force officer                                          | Administrator                     |
	| Car rental agent                                              | Administrator                     |
	| Charity fundraiser                                            | Administrator                     |
	| Civil Service administrative officer                          | Administrator                     |
	| Civil Service executive officer                               | Administrator                     |
	| Credit controller                                             | Administrator                     |
	| Data entry clerk                                              | Administrator                     |
	| Diplomatic Service officer                                    | Administrator                     |
	| Estates officer                                               | Administrator                     |
	| Farm secretary                                                | Administrator                     |
	| Finance officer                                               | Administrator                     |
	| Financial services customer adviser                           | Administrator                     |
	| GP practice manager                                           | Administrator                     |
	| Health and safety adviser                                     | Administrator                     |
	| Health records clerk                                          | Administrator                     |
	| Health service manager                                        | Administrator                     |
	| Human resources officer                                       | Administrator                     |
	| Immigration officer                                           | Administrator                     |
	| Import-export clerk                                           | Administrator                     |
	| Insurance broker                                              | Administrator                     |
	| Insurance technician                                          | Administrator                     |
	| Interpreter                                                   | Administrator                     |
	| Local government administrative assistant                     | Administrator                     |
	| Local government officer                                      | Administrator                     |
	| Local government revenues officer                             | Administrator                     |
	| Medical secretary                                             | Administrator                     |
	| Office manager                                                | Administrator                     |
	| Payroll administrator                                         | Administrator                     |
	| Personal assistant                                            | Administrator                     |
	| Post Office customer service assistant                        | Administrator                     |
	| Proofreader                                                   | Administrator                     |
	| Purchasing manager                                            | Administrator                     |
	| Quality control assistant                                     | Administrator                     |
	| Receptionist                                                  | Administrator                     |
	| Recruitment consultant                                        | Administrator                     |
	| Registrar of births, deaths, marriages and civil partnerships | Administrator                     |
	| Reprographic assistant                                        | Administrator                     |
	| Sales administrator                                           | Administrator                     |
	| School business manager                                       | Administrator                     |
	| School secretary                                              | Administrator                     |
	| Secretary                                                     | Administrator                     |
	| Security Service personnel                                    | Administrator                     |
	| Sports development officer                                    | Administrator                     |
	| Supervisor                                                    | Administrator                     |
	| Telephonist                                                   | Administrator                     |
	| Town planning assistant                                       | Administrator                     |
	| Trade union official                                          | Administrator                     |
	| Trading standards officer                                     | Administrator                     |
	| Agricultural contractor                                       | Animal care                       |
	| Agricultural inspector                                        | Animal care                       |
	| Animal care worker                                            | Animal care                       |
	| Animal technician                                             | Animal care                       |
	| Dog training and behaviour adviser                            | Animal care                       |
	| Beekeeper                                                     | Animal care                       |
	| Biologist                                                     | Animal care                       |
	| Countryside ranger                                            | Animal care                       |
	| Dog groomer                                                   | Animal care                       |
	| Dog handler                                                   | Animal care                       |
	| Ecologist                                                     | Animal care                       |
	| Farm worker                                                   | Animal care                       |
	| Farmer                                                        | Animal care                       |
	| Farrier                                                       | Animal care                       |
	| Fish farmer                                                   | Animal care                       |
	| Fishing boat deckhand                                         | Animal care                       |
	| Gamekeeper                                                    | Animal care                       |
	| Horse groom                                                   | Animal care                       |
	| Horse riding instructor                                       | Animal care                       |
	| Jockey                                                        | Animal care                       |
	| Kennel worker                                                 | Animal care                       |
	| Pet behaviour consultant                                      | Animal care                       |
	| Pet shop assistant                                            | Animal care                       |
	| RSPCA inspector                                               | Animal care                       |
	| Racehorse trainer                                             | Animal care                       |
	| Vet                                                           | Animal care                       |
	| Veterinary nurse                                              | Animal care                       |
	| Veterinary physiotherapist                                    | Animal care                       |
	| Zookeeper                                                     | Animal care                       |
	| Zoologist                                                     | Animal care                       |
	| Local government administrative assistant                     | Animal care                       |
	| Local government officer                                      | Animal care                       |
	| Local government revenues officer                             | Animal care                       |
	| Medical secretary                                             | Animal care                       |
	| Office manager                                                | Animal care                       |
	| Payroll administrator                                         | Animal care                       |
	| Personal assistant                                            | Animal care                       |
	| Post Office customer service assistant                        | Animal care                       |
	| Proofreader                                                   | Animal care                       |
	| Purchasing manager                                            | Animal care                       |
	| Quality control assistant                                     | Animal care                       |
	| Receptionist                                                  | Animal care                       |
	| Recruitment consultant                                        | Animal care                       |
	| Registrar of births, deaths, marriages and civil partnerships | Animal care                       |
	| Reprographic assistant                                        | Animal care                       |
	| Sales administrator                                           | Animal care                       |
	| School business manager                                       | Animal care                       |
	| School secretary                                              | Animal care                       |
	| Secretary                                                     | Animal care                       |
	| Security Service personnel                                    | Animal care                       |
	| Sports development officer                                    | Animal care                       |
	| Supervisor                                                    | Animal care                       |
	| Telephonist                                                   | Animal care                       |
	| Town planning assistant                                       | Animal care                       |
	| Trade union official                                          | Animal care                       |
	| Trading standards officer                                     | Animal care                       |
	| Acupuncturist                                                 | Beauty and wellbeing              |
	| Aromatherapist                                                | Beauty and wellbeing              |
	| Art therapist                                                 | Beauty and wellbeing              |
	| Barber                                                        | Beauty and wellbeing              |
	| Beauty consultant                                             | Beauty and wellbeing              |
	| Beauty therapist                                              | Beauty and wellbeing              |
	| Chiropractor                                                  | Beauty and wellbeing              |
	| Counsellor                                                    | Beauty and wellbeing              |
	| Dance movement psychotherapist                                | Beauty and wellbeing              |
	| Dramatherapist                                                | Beauty and wellbeing              |
	| Hairdresser                                                   | Beauty and wellbeing              |
	| Health play specialist                                        | Beauty and wellbeing              |
	| Homeopath                                                     | Beauty and wellbeing              |
	| Massage therapist                                             | Beauty and wellbeing              |
	| Medical herbalist                                             | Beauty and wellbeing              |
	| Music therapist                                               | Beauty and wellbeing              |
	| Nail technician                                               | Beauty and wellbeing              |
	| Naturopath                                                    | Beauty and wellbeing              |
	| Nutritional therapist                                         | Beauty and wellbeing              |
	| Osteopath                                                     | Beauty and wellbeing              |
	| Pilates teacher                                               | Beauty and wellbeing              |
	| Reflexologist                                                 | Beauty and wellbeing              |
	| Reiki healer                                                  | Beauty and wellbeing              |
	| Tattooist and body piercer                                    | Beauty and wellbeing              |
	| Yoga therapist                                                | Beauty and wellbeing              |
	| Accounting technician                                         | Business and finance              |
	| Actuary                                                       | Business and finance              |
	| Auditor                                                       | Business and finance              |
	| Bank manager                                                  | Business and finance              |
	| Banking customer service adviser                              | Business and finance              |
	| Bookkeeper                                                    | Business and finance              |
	| Business adviser                                              | Business and finance              |
	| Business development manager                                  | Business and finance              |
	| Business project manager                                      | Business and finance              |
	| Chief executive                                               | Business and finance              |
	| Company secretary                                             | Business and finance              |
	| Corporate responsibility and sustainability practitioner      | Business and finance              |
	| Credit controller                                             | Business and finance              |
	| Credit manager                                                | Business and finance              |
	| Economist                                                     | Business and finance              |
	| Finance officer                                               | Business and finance              |
	| Financial adviser                                             | Business and finance              |
	| Financial services customer adviser                           | Business and finance              |
	| Insurance account manager                                     | Business and finance              |
	| Insurance broker                                              | Business and finance              |
	| Insurance claims handler                                      | Business and finance              |
	| Insurance loss adjuster                                       | Business and finance              |
	| Insurance risk surveyor                                       | Business and finance              |
	| Insurance technician                                          | Business and finance              |
	| Insurance underwriter                                         | Business and finance              |
	| Investment analyst                                            | Business and finance              |
	| Local government revenues officer                             | Business and finance              |
	| Management accountant                                         | Business and finance              |
	| Market research executive                                     | Business and finance              |
	| Marketing manager                                             | Business and finance              |
	| Money adviser                                                 | Business and finance              |
	| Mortgage adviser                                              | Business and finance              |
	| Payroll administrator                                         | Business and finance              |
	| Payroll manager                                               | Business and finance              |
	| Pensions administrator                                        | Business and finance              |
	| Pensions adviser                                              | Business and finance              |
	| Private practice accountant                                   | Business and finance              |
	| Public finance accountant                                     | Business and finance              |
	| School business manager                                       | Business and finance              |
	| Stockbroker                                                   | Business and finance              |
	| Tax adviser                                                   | Business and finance              |
	| Tax inspector                                                 | Business and finance              |
	| 3D printing technician                                        | Computing, technology and digital |
	| App developer                                                 | Computing, technology and digital |
	| Archivist                                                     | Computing, technology and digital |
	| Business analyst                                              | Computing, technology and digital |
	| Cartographer                                                  | Computing, technology and digital |
	| Computer games developer                                      | Computing, technology and digital |
	| Computer games tester                                         | Computing, technology and digital |
	| Cyber intelligence officer                                    | Computing, technology and digital |
	| Data entry clerk                                              | Computing, technology and digital |
	| Data scientist                                                | Computing, technology and digital |
	| Database administrator                                        | Computing, technology and digital |
	| Digital delivery manager                                      | Computing, technology and digital |
	| Digital product owner                                         | Computing, technology and digital |
	| E-learning developer                                          | Computing, technology and digital |
	| Forensic computer analyst                                     | Computing, technology and digital |
	| Geospatial technician                                         | Computing, technology and digital |
	| IT project manager                                            | Computing, technology and digital |
	| IT security co-ordinator                                      | Computing, technology and digital |
	| IT support technician                                         | Computing, technology and digital |
	| IT trainer                                                    | Computing, technology and digital |
	| Indexer                                                       | Computing, technology and digital |
	| Information scientist                                         | Computing, technology and digital |
	| Librarian                                                     | Computing, technology and digital |
	| Library assistant                                             | Computing, technology and digital |
	| Media researcher                                              | Computing, technology and digital |
	| Network engineer                                              | Computing, technology and digital |
	| Network manager                                               | Computing, technology and digital |
	| Operational researcher                                        | Computing, technology and digital |
	| Pre-press operator                                            | Computing, technology and digital |
	| Robotics engineer                                             | Computing, technology and digital |
	| Security Service personnel                                    | Computing, technology and digital |
	| Social media manager                                          | Computing, technology and digital |
	| Software developer                                            | Computing, technology and digital |
	| Solutions architect                                           | Computing, technology and digital |
	| Systems analyst                                               | Computing, technology and digital |
	| Technical architect                                           | Computing, technology and digital |
	| Technical author                                              | Computing, technology and digital |
	| Telephonist                                                   | Computing, technology and digital |
	| Test lead                                                     | Computing, technology and digital |
	| User experience (UX) designer                                 | Computing, technology and digital |
	| User researcher                                               | Computing, technology and digital |
	| Vlogger                                                       | Computing, technology and digital |
	| Web content editor                                            | Computing, technology and digital |
	| Web content manager                                           | Computing, technology and digital |
	| Web designer                                                  | Computing, technology and digital |
	| Web developer                                                 | Computing, technology and digital |