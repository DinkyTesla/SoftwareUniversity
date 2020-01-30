class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = +ramMemory;
        this.cpuGHz = +cpuGHz;
        this.hddMemory = +hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    };

    installAProgram(name, requiredSpace) {

        if (+requiredSpace > this.hddMemory) {
            throw new Error('There is not enough space on the hard drive');
        }

        const obj = { name: `${name}`, requiredSpace: `${requiredSpace}` };
        this.installedPrograms.push(obj);
        this.hddMemory -= +requiredSpace;

        return obj;
    };

    uninstallAProgram(name) {

        if (this.installedPrograms.length === 0) {
            throw "Control panel is not responding"
        }

        for (let index = 0; index < this.installedPrograms.length; index++) {
            if (this.installedPrograms[index].name === name) {
                this.hddMemory += this.installedPrograms[index].requiredSpace;
                this.installedPrograms.splice(index, 1);
            }
        }

        return this.installedPrograms;
    };

    openAProgram(name) {

        let program = {};

        for (let j = 0; j < this.taskManager.length; j++) {
            if (this.taskManager[j].name === name) {
                throw new Error(`The ${name} is already open`);
            }
        }

        for (let index = 0; index < this.installedPrograms.length; index++) {
            if (this.installedPrograms.name === name) {
                let ramMemory = (this.installedPrograms[index] / this.ramMemory) * 1.5;
                let cpuUsage = ( ( this.installedPrograms[index] / this.cpuGHz ) / 500) * 1.5;
            } else {
                throw new Error(`The ${name} is not recognized`);
            }
        }
    };

    taskManagerView() {
        return this.taskManager;
    };

}

var compo = new Computer(5, 5, 5);
console.log(compo.installAProgram('Word', 1));