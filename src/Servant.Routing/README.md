# Servant.Routing
A powerful graph-based routing API that is designed to plug into any C# web framework.

## Features:

- Pluggable into any project that needs routing (Asp.Net, WPF, Universal Windows Platform, Xamarin)
- Built to leverage acyclic directed graphs
- Powerful and performant route selection and binding
- Leverages a pluggable pipeline architecture
- Easily exposed metadata
- Immutable types provide thread-safety across the board

## Core Concepts

- Routes are defined as an acyclic directed graph. This allows route selection to be handled in a performant manner as a large number of non-elligible routes can be eliminated in a single step.
- Pluggable into any project. Because `Servant.Routing` does not make assumptions about the type or form of data that is being routed, it is easily addable to any project, whether it is a web project or a mobile app.
- `Servant.Routing` uses a pipeline architecture. This allows the focus to be on the flow and manipulation of data, not the management of services. What this means for your app is that you can focus on creating functionality and not infrastructure.
