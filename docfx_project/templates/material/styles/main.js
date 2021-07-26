// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.

(function () {
  setTimeout(function () {
    let sourceLink = document.querySelector("ul.navbar-nav li [title=Source]");
    let icon = document.createElement("i");
    icon.className = "fab fa-github";

    sourceLink.prepend(" ");
    sourceLink.prepend(icon);
  }, 700);
})();
