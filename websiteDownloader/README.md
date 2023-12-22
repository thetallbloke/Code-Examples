**Website Downloader**
----------
My baseball club, or any number of clubs, would like a content management system (CMS) to manage their website, but this presents a problem; there is a cost and an overhead to most CMS packages.  They often require a backend database, and that usually costs more in hosting charges.

I have a dev/staging server that I'm happy to open up for select people to modify their site content, but not really happy to have the world hitting my dev server to view the prod site.

Enter the WebsiteDownloader.

In the case of my local baseball club, they have very simple requirements for their website, and a CMS like Umbraco is perfect.

I wanted a way to use a simple free CMS to manage content on a website, but then be able to export the site for hosting.  By generating a static HTML version of the CMS managed site, I could then package it up and deploy to Cloudflare and host it for free.
