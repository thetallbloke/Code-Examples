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


## Errors I've faced

Refreshing the client page causes "Loading..." to be shown forever:
	https://community.auth0.com/t/refreshing-page-cause-loading-stuck-forever/39406


### How to Add Additional Files to the .github Folder in Visual Studio

When you add new .yml files (or any files) to the .github folder, you need to:

#### Manually Update the .sln File

This works perfectly fine, but it's a manual process. Here's how you can do it:

1. Open the .sln file in a text editor
2. Add new files under the SolutionItems section, like this:


	GlobalSection(SolutionItems) = preSolution
		.github\workflows\ci.yml = .github\workflows\ci.yml
		.github\workflows\deploy.yml = .github\workflows\deploy.yml
		.github\workflows\new-workflow.yml = .github\workflows\new-workflow.yml
	EndGlobalSection

3. Save the solution.  If prompted by Visual Studio, reload the solution.

## .NET Core API and React App

There are a few gotchas when combining a .NET Core API and a React app.  I have been able to secure the API using Auth0, and have the React app call the API using the access token.

### Part 1 - .NET Core API

### Part 2 - React App

You can either specify the audience in the Auth0Provider component, or you can specify it in the useAuth0 hook.

** Auth0Provier **

	<Auth0Provider
        domain={import.meta.env.VITE_AUTH0_DOMAIN}
        clientId={import.meta.env.VITE_AUTH0_CLIENT_ID}
        authorizationParams={{
            scope:'openid profile email',
            audience: import.meta.env.VITE_AUTH0_API_AUDIENCE,
            redirect_uri: window.location.origin,
        }}
    >
        <BrowserRouter>
            <App />
        </BrowserRouter>
    </Auth0Provider>

** useAuth0 **

	const token = await getAccessTokenSilently({
		authorizationParams: {
			scope: 'openid profile email',
			audience: `${import.meta.env.VITE_AUTH0_API_AUDIENCE}`
		}
	});

I now specify the audience in the Auth0Provider component for simplicity.  Set it once for the whole app and not have to worry about it for each call to the API.