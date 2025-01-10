# How To Combine React and .NET Core projects

This is a simple example of how to combine a React project with a .NET Core project within the same Visual Studio solution file.

## Steps to create the React project

npm create vite@latest

	Select a framework: » React
	Select a variant: » TypeScript + SWC

--------------------------------------

## How to run

	cd <project-root>
	npm i			(or npm install)
	npm run dev

--------------------------------------

Edit the .vscode/launch.json file to set the dev port number to listen on.

Required Packages

	npm install @auth0/auth0-react
	npm install react-router-dom

--------------------------------------
Copy these into the root of the react folder

	.\.vscode folder  - an example of the .vscode folder is included here, rename `_vscode` to `.vscode`
	.\reactproject1.esproj

These allow the react app to be included in Visual Studio 2022, and maybe opened and started using VSCode

--------------------------------------

-- Install the @auth0 package

	npm install @auth0/auth0-react


---------------------------
Errors I've faced
---------------------------
Refreshing the client page causes "Loading..." to be shown forever:
	https://community.auth0.com/t/refreshing-page-cause-loading-stuck-forever/39406
