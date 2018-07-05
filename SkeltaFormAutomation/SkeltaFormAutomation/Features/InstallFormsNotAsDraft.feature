Feature: InstallFormsNotAsDraft
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@UI
Scenario Outline: Set all forms to Publish during installation
#Launch browser
	Given I launch Chrome
#Navigate to Enterprise Console log in page
	Given I navigate to http://10.184.208.231:8000/EnterpriseConsole/BPMUITemplates/Default/Repository/Site/Login.aspx?_repo=LPS_Repo&_instanceName=MESDB_MES&_provtext=MES%20Users[MESDB_MES]&_prov=mesuserprovider
#Enter credentials and log in
	Given I log in using username <Username> and password <Password>
#Navigate to Package Tempalte in Package
	Given I select Package on Navigation side bar
	Given I select Package Template on Package tab
#Select Skelta Package
	Given I switch to Iframe Mainframe in Package Template
	Given I switch to Iframe Gridframe in Package Template
	Given Skelta Package <Package Name> status is Draft
	Then I select Skelta Package <Package Name>
#Edit Skelta Package
	#Click on Edit Skelta Package
		Given I switch to default Frame
		Given I switch to Iframe Mainframe in Package Template
		Given I select the <ActionName> Package button
	#Add/Edit Package Template Window
		Given I switch to default Frame
		Given I switch to Iframe WindowCloseBehaviour in Package Template
		Given I select <EditPackageTemplateButton> button in Edit Package Template
	#Close Edit Package TEmplate "Saved Successfully Popup"
		Given I switch to default Frame
		Then I close the Popup window
	#Navigate to forms and count forms
		Given Edit Package Template page is open
		Given I switch to Iframe WindowCloseBehaviour in Package Template
		Given I Expand <ArtifactName> under Configuration tab in Edit Package Template
	#Count Number of forms to be updated
		Then I count the number for ChildArtifacts in <ArtifactName>
		Then I identify the Non-folder ChildArtifacts in <ArtifactName>
	#Select Forms to Install the Form in published mode
		Then I select No for 'Install Form as Draft' in Sub Artifact settings
	#Save forms saved
		Then I select '<EPT_button>' button in Edit Package Template window
		
Examples: 
| Browser | URL                                                                  | Username                | Password     | IFrameName | IFrame2Name | Package Name   | Status | ActionName | EditPackageTemplateButton | ArtifactName | Yes/No | Label                 | EPT_button    |
| Chrome  | http://sglab522.singdevlab.dev.wonderware.com:8000/EnterpriseConsole | singdevlab\indsollabusr | IndSolusr101 | Mainframe  | Gridframe   | For Automation | Draft  | Edit       | Save & Continue           | Forms        | No     | Install Form as Draft | Save Template |

@UI
Scenario Outline: Set all Workflows to Publish during installation
#Launch browser
	Given I launch Chrome
#Navigate to Enterprise Console log in page
	Given I navigate to http://10.184.208.231:8000/EnterpriseConsole/BPMUITemplates/Default/Repository/Site/Login.aspx?_repo=LPS_Repo&_instanceName=MESDB_MES&_provtext=MES%20Users[MESDB_MES]&_prov=mesuserprovider
#Enter credentials and log in
	Given I log in using username <Username> and password <Password>
#Navigate to Package Tempalte in Package
	Given I select Package on Navigation side bar
	Given I select Package Template on Package tab
#Select Skelta Package
	Given I switch to Iframe Mainframe in Package Template
	Given I switch to Iframe Gridframe in Package Template
	Given Skelta Package <Package Name> status is Draft
	Then I select Skelta Package <Package Name>
#Edit Skelta Package
	#Click on Edit Skelta Package
		Given I switch to default Frame
		Given I switch to Iframe Mainframe in Package Template
		Given I select the <ActionName> Package button
	#Add/Edit Package Template Window
		Given I switch to default Frame
		Given I switch to Iframe WindowCloseBehaviour in Package Template
		Given I select <EditPackageTemplateButton> button in Edit Package Template
	#Close Edit Package TEmplate "Saved Successfully Popup"
		Given I switch to default Frame
		Then I close the Popup window
	#Navigate to forms and count forms
		Given Edit Package Template page is open
		Given I switch to Iframe WindowCloseBehaviour in Package Template
		Given I Expand <ArtifactName> under Configuration tab in Edit Package Template
	#Count Number of forms to be updated
		Then I count the number for ChildArtifacts in <ArtifactName>
		Then I identify the Non-folder ChildArtifacts in <ArtifactName>
	#Select Forms to Install the Form in published mode
		Then I select <Yes/No> for 'Install Workflow as Draft' in Sub Artifact settings
	#Save forms saved
		Then I select '<EPT_button>' button in Edit Package Template window
		
Examples: 
| Browser | URL                                                                  | Username                | Password     | IFrameName | IFrame2Name | Package Name   | Status | ActionName | EditPackageTemplateButton | ArtifactName | Yes/No | Label                     | EPT_button    |
| Chrome  | http://sglab522.singdevlab.dev.wonderware.com:8000/EnterpriseConsole | singdevlab\indsollabusr | IndSolusr101 | Mainframe  | Gridframe   | For Automation | Draft  | Edit       | Save & Continue           | Workflows    | No     | Install Workflow as Draft | Save Template | 