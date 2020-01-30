function constructionCrew(object){
    if (object.dizziness) {
        let amountToAdd = object.weight * object.experience * 0.1;
        object.levelOfHydrated += amountToAdd;
        object.dizziness = false;
    }
    return object;
}