﻿// JQuery můžeme používat jen když : $(document).ready(function()) { .... };

/// <reference path="scripts/typings/jquery/jquery.d.ts" />
$(document).ready(function () {
    $("body").append(
        $("<p>Nazdar abcd </o>")
    );
});