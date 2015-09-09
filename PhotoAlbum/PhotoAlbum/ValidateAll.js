// Adds a property getter/setter and includes validations
function addDynamicValidatedProperty(object, propName) {
    // dynamically add a property to object
    Object.defineProperty(object, propName, {
        get: function () {
            return this['_' + propName];
        },
        set: function (value) {
            if (value.trim() == '') {
                throw new Error(propName + ' must have a value!');
            }
            this['_' + propName] = value;
        }
    });
}
function addRequiredValidation(object) {
    // loop through object and construct valObject
    var valObject = {};
    for (var prop in object) {
        // if property name starts with 'required_' then dynamic prop
        if (prop.indexOf('required_', 0) == 0) {
            var propName = prop.substring(9);
            addDynamicValidatedProperty(valObject, propName);
        }
        else {
            valObject[prop] = object[prop];
        }
    }
    return valObject;
}
// create a customer
var customer = {
    required_firstName: '',
    required_lastName: '',
    favoriteColor: ''
};
// create validated customer object
var valCustomer = addRequiredValidation(customer);
// dump all of the valCustomer properties to console
console.dir(valCustomer);
// force an exception
valCustomer.firstName = ''; // should throw
