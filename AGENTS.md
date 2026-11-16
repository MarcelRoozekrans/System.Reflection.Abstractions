# AGENTS.md: System.Reflection.Abstractions

Interfaced wrappers around `System.Reflection` types (`Assembly`, `AssemblyName`) so callers can mock
reflection in tests. It ships as one NuGet package, `System.Reflection.Abstractions`, built from the
single project `System.Reflection.Abstractions/System.Reflection.Abstractions.csproj`. There is no test
project and no sample project.

## Layout

- Each wrapped type has an `I<Type>` interface and a wrapper class that forwards to the real type. A
  factory (`I<Type>Factory`, `<Type>Factory`) wraps the static members, and `Reflection` exposes the
  factories as one entry point (`IReflection`).
- Everything is in the single namespace `System.Reflection.Abstractions`, whatever the folder.
  Folders only group a type with its interfaces.
- The `<Type>Factory` classes forward to the framework with `/// <inheritdoc />` docs. XML docs are
  generated (`GenerateDocumentationFile`), so keep them on new public members.

## Build and test

There are no tests, so the build is the only check. Prerequisites: a .NET SDK that can restore the
`net40` and `netstandard2.0` targets. There is no `global.json`, so no SDK is pinned. Building needs no
.NET Framework 4.0 runtime, because the project only compiles against it. Nothing here runs code.

```bash
# AppVeyor, appveyor.yml: restore, then build Release; the nupkg is published as an artifact
nuget restore
# Inner loop, no CI job runs it: restore and build both targets
dotnet build System.Reflection.Abstractions.sln -c Release
```

`appveyor.yml` builds with the Visual Studio 2017 image's default MSBuild step, not `dotnet build`.
The `dotnet build` line was run with SDK 11.0.100 and passed with 0 warnings and 0 errors.
`GeneratePackageOnBuild` makes every build write
`System.Reflection.Abstractions/bin/Release/System.Reflection.Abstractions.<version>.nupkg`.
The GitHub Actions workflow `baseline-checks.yml` has no build command to copy: it calls the shared
`ci-baseline` workflow (gitleaks, CodeQL, NuGetAudit) on the solution.

## Conventions and gotchas

- Exceptions to the org rules in the block below, in so many words:
  - **Default branch:** it is `master`, not `main`. Branch off `master`, open the PR against it, and
    `baseline-checks.yml` runs on pushes to `master`.
  - **Releases:** there is no release-please. Exception to the org release rule: Conventional Commits
    do not open a release PR, and no `release-please-config.json` exists. The package
    version is set in the csproj. `<Version>`, `<AssemblyVersion>` and `<FileVersion>` currently say
    1.0.1 and are changed together, by hand.
  - **CI:** the package is built on AppVeyor (`appveyor.yml`, version `1.0.{build}`), not on GitHub
    Actions. The `ci-baseline` workflows that are called are `baseline.yml` and `history-scan.yml`
    only. The shared build, test and coverage workflows are not used.
  - **Coverage gate:** exception to the org coverage rule. There is no test project and no coverage
    run, so the 80% floor and Codecov do not apply. A change that adds logic should come with a new
    test project, but none exists to extend.
- The two target frameworks are `net40` and `netstandard2.0`. Code must compile on both. Members that
  exist on only one target sit behind `#if NETSTANDARD2_0` in `Assembly.cs`, `IAssembly.cs`,
  `AssemblyName.cs` and `IAssemblyName.cs`. A new wrapper member must be checked against both.
- The `netstandard1.4` item group in the csproj is unreachable, because that framework is not a target.
- The package id, namespace and assembly name are all `System.Reflection.Abstractions`. The namespace
  sits inside `System.Reflection` on purpose, so a wrapper named `Assembly` or `AssemblyName` shadows
  the framework type there. Wrapper code names the framework type fully, as in
  `System.Reflection.Assembly`, and new code should too.

<!-- org-core:start sha256=08a88996bc9165f888fc0260607cfd0670cae128c323e16707c6b452ee66222d (generated from docker-nuc scripts/agents-md/org-core-personal.md; do not edit here) -->
## Org rules

These rules hold in every public MarcelRoozekrans repo.

### Commits and releases

- Conventional Commits. release-please reads them on the default branch, and the changelog sections
  in `release-please-config.json` decide which types count. The standard: `feat`, `fix`, `perf`,
  `deps` and `revert` open or update the release PR; `docs`, `test`, `refactor`, `build`, `ci`,
  `chore` and `style` do not, unless the commit is breaking or has a `Release-As:` footer. The
  release happens when that PR merges. A breaking change needs `!` or a `BREAKING CHANGE:` footer.
- A commit body never contains nested parentheses. release-please cannot parse them and silently
  drops the whole commit from the changelog, while the workflow still reports success.
- After merging a commit that should release, check that it appears in the release-please PR.

### Branches and pull requests

- Every change goes through a branch and a pull request. Never push to the default branch directly.
- A PR body says what the diff does, and nothing the diff does not do.
- Fix review findings in the PR under review, including small ones. File an issue only for a finding
  that belongs to other code, needs a design decision, is its own piece of work, or waits on
  something external.

### CI

- The .NET repos call the shared workflows of `MarcelRoozekrans/ci-baseline`, pinned to `@v1`, never
  `@main`.
- Its coverage gate fails the build when line coverage drops below the floor of 80%, and Codecov
  fails a PR that lowers project coverage by more than 1 percentage point. New code comes with
  tests.
- A repo with a lower floor documents the reason and links the issue that raises it.
<!-- org-core:end -->
