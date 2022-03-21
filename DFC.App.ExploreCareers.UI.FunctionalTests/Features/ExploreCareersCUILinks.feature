Feature: ExploreCareersCUILinks
	As a citizen on the National Careers website 
	I want to be sure that links work fine


Scenario Outline: TCC01 - Job profiles links and breadcrumb verified on being clicked
	Given I am at the "Job categories" web page for <Job category>
	When I click the link for each of the Job profiles listed thereunder in turn
	Then I am navigated to the Job profiles page for the Job profile clicked
	And the breadcrumb for that specific Job profile is displayed
Examples:
	| Job category                      |
	| Administration                    |
	| Animal care                       |
	| Beauty and wellbeing              |
	| Business and finance              |
	| Computing, technology and digital |
	| Construction and trades           |
	| Creative and media                |
	| Delivery and storage              |
	| Emergency and uniform services    |
	| Engineering and maintenance       |
	| Environment and land              |
	| Government services               |
	| Healthcare                        |
	| Home services                     |
	| Hospitality and food              |
	| Law and legal                     |
	| Managerial                        |
	| Manufacturing                     |
	| Retail and sales                  |
	| Science and research              |
	| Social care                       |
	| Sports and leisure                |
	| Teaching and education            |
	| Transport                         |
	| Travel and tourism                |