export class User {
    id = 0;
    fullName = '';
    imageUrl = '';
    address = '';
    email = '';
    password = '';
    tel = '';
    idTypeUser = 0;
    // typeUser = new TypeUser();
    userRoles: UserRole[] = [];
    models: Model[] = [];
    adverts: Advert[] = [];
}

export class TypeUser {
    id = 0;
    name = '';
    users: User[] = [];
}

export class UserRole {
    idUser = 0;
    idRole = 0;
    user = new User();
    role = new Role();
}

export class Advert {
    id = 0;
    idUser = 0;
    idModel = 0;
    dateAdvert = new Date();
    dateSell = new Date();
    state = false;
    user = new User();
    model = new Model();
}

export class Marque {
    id = 0;
    name = '';
    imageUrl = '';
    idCountry = 0;
    country = new Country();
    models: Model[] = [];
}

export class Country {
    id = 0;
    name = '';
    imageUrl = '';
    models: Model[] = [];
}

export class Model {
    id = '';
    idMarque = 0;
    idUser = 0;
    annee = new Date().getFullYear();
    puissance = 0;
    reservoir = 0;
    boiteVitesse = 0;
    freinageUrgence = 0;
    vitesseMax = 0;
    poid = 0;
    prix = 0;
    autonomie = 0;
    consVille = 0;
    consRoute = 0;
    consAutoroute = 0;
    cc = 0;
    idCarburant = 0;
    idTransmission = 0;
    idTypeVoiture = 0;
    user = new User();
    carburant = new Carburant();
    marque = new Marque();
    transmission = new Transmission();
    typeVoiture = new Typevoiture();
    modelImgs: ModelImg[] = [];
    adverts: Advert[] = [];
}

export class ModelImg {
    id = 0;
    imageUrl = '../../assets/not-found.png';
    idModel = '';
    model = new Model();
}

export class Transmission {
    id = 0;
    name = '';
}

export class Role {
    id = 0;
    name = '';
}


export class Carburant {
    id = 0;
    name = '';
}

export class Typevoiture {
    id = 0;
    name = '';
}
