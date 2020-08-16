class Service {
    #collection;
    constructor() {
        this.#collection = new Map();
    }

    add(obj, id) {
        if (id != undefined && obj != undefined)
            this.#collection.set(id, obj);
        else
            return false;
    }

    getById(id) {
        if (id != undefined)
            if (this.#collection.has(id))
                return this.#collection.get(id);
            else
                return false;
        else
            return false;
    }

    getAll() {
        return this.#collection;
    }

    deleteById(id) {
        if (id != undefined)
            if (this.#collection.has(id)) {
                let returned = this.#collection.get(id);
                this.#collection.delete(id);
                return returned;
            }
            else
                return false;
    }

    updateById(id, obj) {
        if (id != undefined && obj != undefined)
            for (let key in this.#collection.get(id))
                this.#collection.get(id)[key] = obj[key];
        else
            return false;
    }

    replaceById(id, obj) {
        if (id != undefined && obj != undefined)
            this.#collection.set(id, obj);
        else
            return false;
    }
}

var storage = new Service();

let human = {
    age: 21,
    name: "Ivan"
};

let human2 = {
    age: 22,
    name: "Vasya"
};

storage.add(human, "Ivan");

storage.updateById("Ivan", human2);