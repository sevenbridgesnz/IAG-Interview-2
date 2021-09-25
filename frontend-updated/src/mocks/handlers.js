import { rest } from 'msw';

export const handlers = [
    rest.get("https://localhost:44387/vehicle-checks/makes", (req, res, ctx) => {
        return res(
            ctx.json(['Lotus', 'BMW', 'Skoda'])
        )
    }),

    rest.get("https://localhost:44387/vehicle-checks/makes/:makeName", (req, res, ctx) => {
        const { makeName } = req.params

        if (makeName.toUpperCase() === 'LOTUS') {
            return res(
                ctx.json({
                    "make": "LOTUS",
                    "models": [{
                        "name": "2 Eleven",
                        "yearsAvailable": 2
                    }, {
                        "name": "Elan",
                        "yearsAvailable": 1
                    }, {
                        "name": "Elise",
                        "yearsAvailable": 14
                    }, {
                        "name": "Esprit",
                        "yearsAvailable": 7
                    }, {
                        "name": "Europa",
                        "yearsAvailable": 2
                    }, {
                        "name": "Evora",
                        "yearsAvailable": 4
                    }, {
                        "name": "Excel",
                        "yearsAvailable": 5
                    }, {
                        "name": "Exige",
                        "yearsAvailable": 5
                    }]
                })
            )
        }

        return res(
            ctx.json({
                make: "Skoda",
                status: "idle",
                models: []
            })
        )
    })
]
