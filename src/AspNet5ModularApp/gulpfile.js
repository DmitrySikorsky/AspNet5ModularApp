/// <binding />
var gulp = require("gulp"),
  runSequence = require("run-sequence");

gulp.task(
  "copy-extensions", function (cb) {
    gulp.src(["../../artifacts/bin/AspNet5ModularApp.Data.Abstractions/Debug/dnxcore50/AspNet5ModularApp.Data.Abstractions.dll"]).pipe(gulp.dest("../../artifacts/bin/Extensions"));
    gulp.src(["../../artifacts/bin/AspNet5ModularApp.Data.EF.Sqlite/Debug/dnxcore50/AspNet5ModularApp.Data.EF.Sqlite.dll"]).pipe(gulp.dest("../../artifacts/bin/Extensions"));
    gulp.src(["../../artifacts/bin/AspNet5ModularApp.Models.Abstractions/Debug/dnxcore50/AspNet5ModularApp.Models.Abstractions.dll"]).pipe(gulp.dest("../../artifacts/bin/Extensions"));

    gulp.src(["../../artifacts/bin/AspNet5ModularApp.ExtensionA/Debug/dnxcore50/AspNet5ModularApp.ExtensionA.dll"]).pipe(gulp.dest("../../artifacts/bin/Extensions"));

    gulp.src(["../../artifacts/bin/AspNet5ModularApp.ExtensionB/Debug/dnxcore50/AspNet5ModularApp.ExtensionB.dll"]).pipe(gulp.dest("../../artifacts/bin/Extensions"));
    gulp.src(["../../artifacts/bin/AspNet5ModularApp.ExtensionB.Data.Abstractions/Debug/dnxcore50/AspNet5ModularApp.ExtensionB.Data.Abstractions.dll"]).pipe(gulp.dest("../../artifacts/bin/Extensions"));
    gulp.src(["../../artifacts/bin/AspNet5ModularApp.ExtensionB.Data.EF.Sqlite/Debug/dnxcore50/AspNet5ModularApp.ExtensionB.Data.EF.Sqlite.dll"]).pipe(gulp.dest("../../artifacts/bin/Extensions"));
    gulp.src(["../../artifacts/bin/AspNet5ModularApp.ExtensionB.Models/Debug/dnxcore50/AspNet5ModularApp.ExtensionB.Models.dll"]).pipe(gulp.dest("../../artifacts/bin/Extensions"));

    cb();
  }
);