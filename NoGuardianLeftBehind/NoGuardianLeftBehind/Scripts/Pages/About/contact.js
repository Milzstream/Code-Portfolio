$(document).ready(function () {

    // Generate a simple captcha
    function randomNumber(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    function generateCaptcha() {
        $('#captchaOperation').html([randomNumber(1, 100), '+', randomNumber(1, 200), '='].join(' '));
    }

    generateCaptcha();

        $('#contactform').formValidation({
            framework: 'bootstrap',
            icon: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            button: {
                selector: '#sendBTN',
                disabled: 'disabled'
            },
            fields: {
                name: {
                    validators: {
                        notEmpty: {
                            message: 'The Name field is required'
                        }
                    }
                },
                email: {
                    validators: {
                        notEmpty: {
                            message: 'The email address is required'
                        },
                        emailAddress: {
                            message: 'The input is not a valid email address'
                        }
                    }
                },
                body: {
                    validators: {
                        notEmpty: {
                            message: 'The Message field is required'
                        }
                    }
                },
                captcha: {
                    validators: {
                        callback: {
                            message: 'Wrong answer',
                            callback: function (value, validator, $field) {
                                var items = $('#captchaOperation').html().split(' '),
                                    sum = parseInt(items[0]) + parseInt(items[2]);
                                return value == sum;
                            }
                        }
                    }
                }
            }

        }).on('err.form.fv', function (e) {
            // Regenerate the captcha
            generateCaptcha();
        }).on('success.form.fv', function (e) {
            // Prevent form submission
            e.preventDefault();

            var $form = $(e.target),
                fv = $(e.target).data('formValidation');

            //Create Validation Data
            var data = { name: $("#nameTB").val(), email: $("#emailTB").val(), body: $("#bodyTB").val() };
            var submitformURL = $('#contactform').data('submit');

            //Submit and get success message
            COMMON.SendToSession(submitformURL, data, "text", COMMON.Message);
        });
});