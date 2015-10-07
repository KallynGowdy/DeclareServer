# Concepts

Servant is a next-gen web framework that is built on ASP.Net 5 with these core values in mind:

1. Security
2. Performance
3. Maintainability
4. and Convention based Configuration for fast-paced development

Each of the sections below will discuss one of these core values in detail.

## Security

Ever heard of sites being hacked (or "pwnd" as the _cool_ kids say)? Nowadays, the ability of attackers to gain unauthorized to websites is at an all time high. Vulnerabilities like [SQL Injection](https://www.owasp.org/index.php/SQL_Injection), [Cross-Site Scripting (XSS)](https://www.owasp.org/index.php/Cross-site_Scripting_(XSS)), and [Cross-Site Request Forgery](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)) or [Insecure Authentication and Session Mechanisms](https://www.owasp.org/index.php/Top_10_2013-A2-Broken_Authentication_and_Session_Management) provide backdoors to the data that you are entrusted to protect.

Servant focuses on providing you with the tools required to make a secure website without obscene amounts of work. Most of these security features will be built into the Servant libraries, making them easy to take advantage of, but some others will be optional, but highly encouraged.

## Performance

Servant is a .Net library. Simply put, a compiled language should be fast, much faster than you could ever get with an interpreted language.

Servant takes this a step further by intentionally doing the least amount of work required for a task. On top of that, Servant encourages you to write performant code by providing performance-central libraries for you to use in your application code.

## Maintainability

They say that in the long run software maintenance costs more than development. This is certainly true in the case of large enterprise-level systems like Google, Amazon, Facebook, Github, etc.

Servant makes maintaining your application easy by providing you with an extensible framework that is composed of simple interchangeable components. Don't like the router? Swap it out for another. Don't like the view renderer? Get rid of it. Want extra features? Extend the current implementations.

## Convention based Configuration

In a lot of new application frameworks, there's this concept of "Convention _over_ configuration". Which essentially means that the framework developer picks the right configuration for you and builds it into the framework. This either makes the framework unable to cope with specific configuration requirements or more difficult due to the documentation around configuration being scarce.

Servant gives you sane configuration defaults if you just want to get going quickly, but also gives you a rich, easy-to-use API for configuring the framework to fit your needs.

This feature is especially important for migrating an existing system to Servant. If you need to keep behavior that was critical to the existing system, it is easy to get Servant to comply. Also, because Servant is built on OWIN, it is easy to relegate Servant to a certain portion of your application, allowing you to keep the old system while working on a new system.

## Is Servant just another MVC Framework?

Considering how popular MVC frameworks are now, that is not a bad question. I would say no, Servant is not a MVC framework, and here's why:

> MVC wasn't designed with web frameworks in mind.

MVC, while a nice, usable pattern, was simply not designed with certain web concepts in mind such as the request-response cycle or routing. As such, frameworks that use the MVC pattern generally suffer from having a less optimized system for handling problems like resource based routing, API discovery, input validation, and most importantly, a security first mindset.
