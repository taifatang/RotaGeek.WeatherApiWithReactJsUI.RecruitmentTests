//Partially Deprecated: Not using babel, only used for sass

var gulp = require("gulp"),
    sass = require("gulp-sass"),
    rename = require("gulp-rename"),
    del = require('del'),
    run = require('gulp-run'),
    less = require('gulp-less'),
    cssmin = require('gulp-minify-css'),
    browserify = require('browserify'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    jshint = require('gulp-jshint'),
    browserSync = require('browser-sync'),
    source = require('vinyl-source-stream'),
    buffer = require('vinyl-buffer'),
    reactify = require('reactify'),
    package = require('./package.json'),
    reload = browserSync.reload;


gulp.task('npm', function () {
    run('npm install').exec();
})

    .task('clean', function (cb) {
        del(['dist/**'], cb);
    })

    .task('server', function () {
        browserSync({
            server: {
                baseDir: './'
            }
        });
    })

    .task("sass", function () {
        return gulp.src(package.paths.sass)
            .pipe(sass())
            .pipe(concat(package.dest.style))
            .pipe(gulp.dest(package.dest.dist));
    })

    .task("sass:min", function () {
        return gulp.src(package.paths.sass)
            .pipe(sass())
            .pipe(concat(package.dest.style))
            .pipe(cssmin())
            .pipe(gulp.dest(package.dest.dist));
    })

    .task('lint', function () {
        return gulp.src(package.paths.js)
            .pipe(jshint())
            .pipe(jshint.reporter('default'));
    })


    .task('js', function () {
        return browserify(package.paths.app)
            .transform(reactify)
            .bundle()
            .pipe(source(package.dest.app))
            .pipe(gulp.dest(package.dest.dist));
    })

    .task('js:min', function () {
        return browserify(package.paths.app)
            .transform(reactify)
            .bundle()
            .pipe(source(package.dest.app))
            .pipe(buffer())
            .pipe(uglify())
            .pipe(gulp.dest(package.dest.dist));
    })

    .task('build', ['npm', 'clean', 'lint', 'sass', 'js'])

    .task('serve', ['npm', 'clean', 'lint', 'sass', 'js', 'server'], function () {
        return gulp.watch([
            package.paths.js, package.paths.jsx, package.paths.html, package.paths.less
        ], [
                'lint', 'less', 'js', browserSync.reload
            ]);
    })

    .task('serve:minified', ['npm', 'clean', 'lint', 'sass:min', 'js:min', 'server'], function () {
        return gulp.watch([
            package.paths.js, package.paths.jsx, package.paths.html, package.paths.less
        ], [
                'lint', 'less:min', 'js:min', browserSync.reload
            ]);
    });

